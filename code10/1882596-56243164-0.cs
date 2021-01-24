      var result = new ValuesController1().Get(1);
    
      var response = result.ExecuteAsync(new System.Threading.CancellationToken());
    
      Assert.AreEqual("value", response.Result.Content);
