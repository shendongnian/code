    List<Observation> testData = GetTestDataList();  //Get some test data as Observations
    
       // Create a prediction engine from the model for feeding new data.
      var engine = mlContext.Model.CreatePredictionEngine<Observation, ModelOutput>(model);
       
       //Make a prediction. The result is of type Output, class shown below.        
       var output = engine.Predict(testData[0]);
