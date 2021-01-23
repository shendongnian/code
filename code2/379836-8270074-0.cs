    Sitecore.Data.Database masterDb = Sitecore.Configuration.Factory.GetDatabase("master");
    using (new Sitecore.SecurityModel.SecurityDisabler())
    {
        try
        {                     
            var templates = TemplateManager.GetTemplates(masterDb);
            foreach (var template in templates.Values)
            {                         
                if (template.FullName.StartsWith("FolderName"))
                {                             
                    var tmpl = masterDb.GetTemplate(template.ID);
                    foreach (var section in tmpl.GetSections())
                    {                                 
                        foreach (var templateFieldItem in section.GetFields())
                        {
                            templateFieldItem.BeginEdit();
                            templateFieldItem.InnerItem[TemplateFieldIDs.Shared] = "0";
                            templateFieldItem.EndEdit();   
                        }    
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("Error" + ex.Message);
        }
    }
