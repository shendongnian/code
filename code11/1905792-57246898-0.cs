    public static ITransformer CreateClassificationModel(MLContext mlContext, DataTable data, List<string> predictorColumns, String TargetColumn, Dictionary<string, int> TargetMapper)
            {
                //Create instances of the GENERIC class Observation and set the values from the DataTable
                //using only the required predictor columns and the target column
                List<Observation> observations = new List<Observation>();
                int iRow = 0;
                foreach (DataRow row in data.Rows)
                {
                    var obs = new Observation();
                   
                    int iFeature = 0;
                    foreach (string predictorColumn in predictorColumns)
                    {
                        obs.Features[iFeature] = Convert.ToSingle(row[predictorColumn]);
                        iFeature++;
                    }
                    obs.Target = TargetMapper[row[TargetColumn].ToString()];                
                    observations.Add(obs);
                    iRow++;
                }
    
                IEnumerable<Observation> dataNew = observations;
    
                var definedSchema = SchemaDefinition.Create(typeof(Observation));
    
                // Read the data into an IDataView with the modified schema supplied in
                IDataView trainingDataView = mlContext.Data.LoadFromEnumerable(observations, definedSchema);
                
                var featureSet = new String[1];  
                featureSet[0] = "Features";
    
                // Data process configuration with pipeline data transformations 
                var dataProcessPipeline = mlContext.Transforms.Conversion.MapValueToKey("Target", "Target")
                                          .Append(mlContext.Transforms.Concatenate("Features", featureSet))
                                          .AppendCacheCheckpoint(mlContext);
    
                // Set the training algorithm 
                var trainer = mlContext.MulticlassClassification.Trainers.LbfgsMaximumEntropy(labelColumnName: "Target", featureColumnName: "Features")
                                          .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel", "PredictedLabel"));
                IEstimator<ITransformer> trainingPipeline = trainingPipeline = dataProcessPipeline.Append(trainer);
    
    
                // Evaluate quality of Model
                var crossValidationResults = mlContext.MulticlassClassification.CrossValidate(trainingDataView, trainingPipeline, numberOfFolds: 5, labelColumnName: "Target");
    
                // Train Model
                ITransformer model = trainingPipeline.Fit(trainingDataView);
    
    
                return model;
            }
