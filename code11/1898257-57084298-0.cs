     IDataView data = mlContext.Data.LoadFromEnumerable(samples);
            string featuresColumnName = "Features";
            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding(
                new[]
                {
                    new InputOutputColumnPair("Education"),
                    new InputOutputColumnPair("ZipCode")
                }).Append(mlContext.Transforms.Concatenate("Features", "Education", "ZipCode"))
                .Append(mlContext.Clustering.Trainers.KMeans(featuresColumnName, numberOfClusters: 2));
            var model = pipeline.Fit(data);
            var predictor = mlContext.Model.CreatePredictionEngine<DataPoint, ClusterPredictionItem>(model);
