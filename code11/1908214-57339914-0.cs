    public async Task<string> GetMailTemplateByType(Models.TemplateTypes type)
    {
      var mailTemplate = /*your expression from screenshot*/.FirstOrDefault();
      if(mailTemplate = null)
        throw new NullReferenceException();
      return mailTemplate;
    }
    ..........................
    try
    {
      GetMailTemplateByType(TemplateTypesVariable);
    }
    catch(NullReferenceException err)
    {
       Console.WriteLine("template does not exist");
    }
