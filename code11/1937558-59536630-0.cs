    public void InspectFastTreeModelParameters()
    {
        var mlContext = new MLContext(seed: 1);
 
        var data = mlContext.Data.LoadFromTextFile<TweetSentiment>(TestCommon.GetDataPath(DataDir, TestDatasets.Sentiment.trainFilename),
            hasHeader: TestDatasets.Sentiment.fileHasHeader,
            separatorChar: TestDatasets.Sentiment.fileSeparator,
            allowQuoting: TestDatasets.Sentiment.allowQuoting);
 
        // Create a training pipeline.
        var pipeline = mlContext.Transforms.Text.FeaturizeText("Features", "SentimentText")
            .AppendCacheCheckpoint(mlContext)
            .Append(mlContext.BinaryClassification.Trainers.FastTree(
                new FastTreeBinaryTrainer.Options{ NumberOfLeaves = 5, NumberOfTrees= 3, NumberOfThreads = 1 }));
 
        // Fit the pipeline.
        var model = pipeline.Fit(data);
 
        // Extract the boosted tree model.
        var fastTreeModel = model.LastTransformer.Model.SubModel;
 
        // Extract the learned GBDT model.
        var treeCollection = fastTreeModel.TrainedTreeEnsemble;
 
        // Make sure the tree models were formed as expected.
        Assert.Equal(3, treeCollection.Trees.Count);
        Assert.Equal(3, treeCollection.TreeWeights.Count);
        Assert.All(treeCollection.TreeWeights, weight => Assert.Equal(1.0, weight));
        Assert.All(treeCollection.Trees, tree =>
        {
            Assert.Equal(5, tree.NumberOfLeaves);
            Assert.Equal(4, tree.NumberOfNodes);
            Assert.Equal(tree.SplitGains.Count, tree.NumberOfNodes);
            Assert.Equal(tree.NumericalSplitThresholds.Count, tree.NumberOfNodes);
            Assert.All(tree.CategoricalSplitFlags, flag => Assert.False(flag));
            Assert.Equal(0, tree.GetCategoricalSplitFeaturesAt(0).Count);
            Assert.Equal(0, tree.GetCategoricalCategoricalSplitFeatureRangeAt(0).Count);
        });
 
        // Add baselines for the model.
        // Verify that there is no bias.
        Assert.Equal(0, treeCollection.Bias);
        // Check the parameters of the final tree.
        var finalTree = treeCollection.Trees[2];
        Assert.Equal(finalTree.LeftChild, new int[] { 2, -2, -1, -3 });
        Assert.Equal(finalTree.RightChild, new int[] { 1, 3, -4, -5 });
        Assert.Equal(finalTree.NumericalSplitFeatureIndexes, new int[] { 14, 294, 633, 266 });
        var expectedSplitGains = new double[] { 0.52634223978445616, 0.45899249367725858, 0.44142707650267105, 0.38348634823264854 };
        var expectedThresholds = new float[] { 0.0911167f, 0.06509889f, 0.019873254f, 0.0361835f };
        for (int i = 0; i < finalTree.NumberOfNodes; ++i)
        {
            Assert.Equal(expectedSplitGains[i], finalTree.SplitGains[i], 6);
            Assert.Equal(expectedThresholds[i], finalTree.NumericalSplitThresholds[i], 6);
        }
    }
