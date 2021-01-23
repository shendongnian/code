    //force the properties to be loaded from the web.config section
                NameValueCollection quartzSection = (NameValueCollection)ConfigurationManager.GetSection("quartz");
                if (quartzSection != null)
                {
                    var quartzProperties = quartzSection.AllKeys.SelectMany(quartzSection.GetValues, (k, v) => new { key = k, value = v });
    
                    foreach (var property in quartzProperties)
                    {
                        properties.Add(property.key, property.value);
                    }
                }
