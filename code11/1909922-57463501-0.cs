    public ActionResult UpdateFileDocsListedDocs(FormCollection form) 
    {
      var oriSetor = FileViewModel.Instance.FileDados.OriCodigo;
      IValueProvider valueProvider = form.ToValueProvider();
      var openAsDic =  new Dictionary<string, object>();
      foreach (string key in form.Keys)
      {
        ValueProviderResult result = valueProvider.GetValue(key);
        object value = result.RawValue;
        openAsDic.Add(key, value);
      }
      var dicToJson = JsonConvert.SerializeObject(openAsDic, Formatting.Indented);
      var jsonToModel = JsonConvert.DeserializeObject<RootObject>(dicToJson);
    
      if (user.Setor == oriSetor)
      {
        for (int i = 0; i < jsonToModel.ControleId.Count(); i++)
        {
          var buildModelObject = new FileDocuments();
          buildModelObject.ControleId = jsonToModel.ControleId[i];
          buildModelObject.NameFileCust = jsonToModel.NameFileCust[i] == null ? "" : jsonToModel.NameFileCust[i];
          buildModelObject.FlagCtb = jsonToModel.FlagCtb[i];
          buildModelObject.FlagCom = jsonToModel.FlagCom[i];
          buildModelObject.FlagSite = jsonToModel.FlagSite[i];
          _context.UpdateFileIntra(buildModelObject.ControleId, buildModelObject.NameFileCust, buildModelObject.FlagCtb, buildModelObject.FlagCom, buildModelObject.FlagSite, user.UserId);
        }
      }
      else
      {
        FileViewModel.Instance.HasError = true;
      }
    
    
      return RedirectToAction("GetFile", "File", new { fileCodigo = fileCodigo });
    }
