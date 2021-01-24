    var categoricalEstimator = mlContext.Transforms.Categorical.OneHotEncoding("BusinessTravel");
    dataView = categoricalEstimator.Fit(dataView).Transform(dataView);
    
    DataOperationsCatalog.TrainTestData dataSplit = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
    IDataView trainData = dataSplit.TrainSet;
    IDataView testData = dataSplit.TestSet;
    
    var pipeline = mlContext.Transforms.Concatenate("Features", featureColumns)
    .Append(mlContext.Transforms.NormalizeMinMax("Features"))                    .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression());
    
    var model = pipeline.Fit(trainData);
    var transformedData = model.Transform(trainData);
    var linearPredictor = model.LastTransformer;
    
    var permutationMetrics = mlContext.BinaryClassification.PermutationFeatureImportance(linearPredictor, transformedData, permutationCount: 30);
    
    var sortedIndices = permutationMetrics.Select((metrics, index) => new { index, metrics.AreaUnderRocCurve })
                    .OrderByDescending(feature => Math.Abs(feature.AreaUnderRocCurve.Mean))
                    .Select(feature => feature.index);
    
    
                var sb = new System.Text.StringBuilder();
    
                // Calculate metrics of the model on the test data.
                var trainedModelMetrics = mlContext.BinaryClassification.Evaluate(model.Transform(testData), labelColumnName: "Label");
    
                sb.Append("<h1>Binary Classification Model, Predicting Employee Turnover</h1>");
                sb.Append(String.Format("<h3>Accuracy:{0}</h3>",trainedModelMetrics.Accuracy));
                sb.Append(String.Format("<h3>F1Score:{0}</h3>", trainedModelMetrics.F1Score));
    
                sb.Append("<table border=1><thead><tr><th>Feature</th><th>Model Weight</th><th>Change in AUC</th><th>95% Confidence in the Mean Change in AUC</th></tr></thead><tbody>");
                var auc = permutationMetrics.Select(x => x.AreaUnderRocCurve).ToArray();
    
                foreach (int i in sortedIndices)
                {
                    if (transformedData.Schema[i].IsHidden || transformedData.Schema[i].Name == "Label" || transformedData.Schema[i].Name == "Features")
                    {
                        continue;
                    }
    
                    var s = String.Format("<tr><td>{0}</td><td>{1:0.00}</td><td>{2:G4}</td><td>{3:G4}</td></tr>",
                        transformedData.Schema[i].Name,
                        linearPredictor.Model.SubModel.Weights[i],
                        auc[i].Mean,
                        1.96 * auc[i].StandardError);
                    sb.Append(s);
                }
                sb.Append("</tbody></table>");
    
    
    
                return Content(sb.ToString());
