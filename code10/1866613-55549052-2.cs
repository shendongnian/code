     public AlternateView MailBodyTemplate(ListDictionary replaceList, string fileName)
        {
            AlternateView plainView = null;
            string templatePath = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/MailTemplate/" + fileName + ".txt");
            if (File.Exists(templatePath))
            {
                string templateContent = File.ReadAllText(templatePath);
                foreach (DictionaryEntry item in replaceList)
                {
                    if (item.Value != null)
                        templateContent = templateContent.Replace(item.Key.ToString(), item.Value.ToString());
                    else
                        templateContent = templateContent.Replace(item.Key.ToString(), string.Empty);
                }
                plainView = AlternateView.CreateAlternateViewFromString(templateContent, null, MediaTypeNames.Text.Html);
            }
            return plainView;
        }
