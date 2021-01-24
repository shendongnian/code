    public ActionResult Index(string jsonModel)
    {
      var serializer= new DataContractJsonSerializer(typeof(Model.DDTListViewModel));
      var yourmodel=  (DDTListViewModel)serializer.ReadObject(GenerateStreamFromString(jsonModel));
    }
