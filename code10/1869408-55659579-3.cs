    Imports System
    Imports System.Collections.Generic
    Imports System.IO
    Imports System.Linq
    Imports Microsoft.Data.DataView
    Imports Microsoft.ML
    Imports Microsoft.ML.Data
    Imports Microsoft.ML.Trainers
    Imports Microsoft.ML.Transforms.Text
    
    Module Module1
    
        Public _dataPath As String = Path.Combine(Environment.CurrentDirectory, "Data", "yelp_labelled.txt")
        Public _modelPath As String = Path.Combine(Environment.CurrentDirectory, "Data", "Model.zip")
    
        Sub Main()
    
            Dim mlcontext As MLContext = New MLContext()
            Dim splitDataView As TrainCatalogBase.TrainTestData = LoadData(mlcontext)
            Dim model As ITransformer = BuildAndTrainModel(mlcontext, splitDataView.TrainSet)
            Evaluate(mlcontext, model, splitDataView.TestSet)
            UseModelWithSingleItem(mlcontext, model)
    
            UseLoadedModelWithBatchItems(mlcontext)
    
            Console.WriteLine()
            Console.WriteLine("=============== End of process ===============")
    
            Console.ReadLine()
    
        End Sub
    
        Public Function LoadData(ByVal mlContext As MLContext) As TrainCatalogBase.TrainTestData
            Dim dataView As IDataView = mlContext.Data.LoadFromTextFile(Of SentimentData)(_dataPath, hasHeader:=False)
            Dim splitDataView As TrainCatalogBase.TrainTestData = mlContext.BinaryClassification.TrainTestSplit(dataView, testFraction:=0.2)
            Return splitDataView
        End Function
    
        Public Function BuildAndTrainModel(ByVal mlContext As MLContext, ByVal splitTrainSet As IDataView) As ITransformer
            Dim pipeline = mlContext.Transforms.Text.FeaturizeText(outputColumnName:=DefaultColumnNames.Features, inputColumnName:=NameOf(SentimentData.SentimentText)).Append(mlContext.BinaryClassification.Trainers.FastTree(numLeaves:=50, numTrees:=50, minDatapointsInLeaves:=20))
            Console.WriteLine("=============== Create and Train the Model ===============")
            Dim model = pipeline.Fit(splitTrainSet)
            Console.WriteLine("=============== End of training ===============")
            Console.WriteLine()
            Return model
        End Function
    
        Public Sub Evaluate(ByVal mlContext As MLContext, ByVal model As ITransformer, ByVal splitTestSet As IDataView)
            Console.WriteLine("=============== Evaluating Model accuracy with Test data===============")
            Dim predictions As IDataView = model.Transform(splitTestSet)
            Dim metrics As CalibratedBinaryClassificationMetrics = mlContext.BinaryClassification.Evaluate(predictions, "Label")
            Console.WriteLine()
            Console.WriteLine("Model quality metrics evaluation")
            Console.WriteLine("--------------------------------")
            Console.WriteLine($"Accuracy: {metrics.Accuracy}")
            Console.WriteLine($"Auc: {metrics.Auc}")
            Console.WriteLine($"F1Score: {metrics.F1Score}")
            Console.WriteLine("=============== End of model evaluation ===============")
            SaveModelAsFile(mlContext, model)
        End Sub
    
        Private Sub UseModelWithSingleItem(ByVal mlContext As MLContext, ByVal model As ITransformer)
            Dim predictionFunction As PredictionEngine(Of SentimentData, SentimentPrediction) = model.CreatePredictionEngine(Of SentimentData, SentimentPrediction)(mlContext)
            Dim sampleStatement As SentimentData = New SentimentData With {
                .SentimentText = "This was a very bad steak"
            }
            Dim resultprediction = predictionFunction.Predict(sampleStatement)
            Console.WriteLine()
            Console.WriteLine("=============== Prediction Test of model with a single sample and test dataset ===============")
            Console.WriteLine()
            Console.WriteLine($"Sentiment: {sampleStatement.SentimentText} | Prediction: {(If(Convert.ToBoolean(resultprediction.Prediction), "Positive", "Negative"))} | Probability: {resultprediction.Probability} ")
            Console.WriteLine("=============== End of Predictions ===============")
            Console.WriteLine()
        End Sub
    
        Public Sub UseLoadedModelWithBatchItems(ByVal mlContext As MLContext)
            Dim sentiments As IEnumerable(Of SentimentData) = {New SentimentData With {
                .SentimentText = "This was a horrible meal"
            }, New SentimentData With {
                .SentimentText = "I love this spaghetti."
            }}
    
            Dim loadedModel As ITransformer
            Using s1 As IO.FileStream = New FileStream(_modelPath, FileMode.Open, FileAccess.Read, FileShare.Read)
                loadedModel = mlContext.Model.Load(s1)
            End Using
    
            Dim sentimentStreamingDataView As IDataView = mlContext.Data.LoadFromEnumerable(sentiments)
            Dim predictions As IDataView = loadedModel.Transform(sentimentStreamingDataView)
            Dim predictedResults As IEnumerable(Of SentimentPrediction) = mlContext.Data.CreateEnumerable(Of SentimentPrediction)(predictions, reuseRowObject:=False)
            Console.WriteLine()
    
            Console.WriteLine("=============== Prediction Test of loaded model with a multiple samples ===============")
    
            Console.WriteLine()
    
            Dim sentimentsAndPredictions = sentiments.Zip(predictedResults, Function(sentiment As SentimentData, prediction As SentimentPrediction) (sentiment, prediction))
    
            For Each item In sentimentsAndPredictions
                Dim result = item.ToTuple
                Console.WriteLine("Sentiment: " & result.Item1.SentimentText & " | Prediction: " & If(Convert.ToBoolean(result.Item2.Prediction), "Positive", "Negative"))
            Next
    
        End Sub
    
        Private Sub SaveModelAsFile(ByVal mlContext As MLContext, ByVal model As ITransformer)
            Using fs = New FileStream(_modelPath, FileMode.Create, FileAccess.Write, FileShare.Write)
                mlContext.Model.Save(model, fs)
            End Using
    
            Console.WriteLine("The model is saved to {0}", _modelPath)
        End Sub
    
    End Module
    
