      var controller = new ValuesController();
      controller.Configuration = new System.Web.Http.HttpConfiguration();
      controller.Request = new System.Net.Http.HttpRequestMessage();
      var result = controller.Get(1);
      var response = result.ExecuteAsync(new System.Threading.CancellationToken());
      String deserialized = response.Result.Content.ReadAsStringAsync().Result;
      Assert.AreEqual("\"value\"", deserialized);
