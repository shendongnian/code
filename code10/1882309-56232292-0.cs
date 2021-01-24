               using (SPSite site = new SPSite("http://sp/sites/jerry"))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        var list = web.Lists.TryGetList("TestList");
                        var item = list.GetItemById(1);
                        var eventDescField = list.Fields.GetFieldByInternalName("Parameters");
                        var eventDesc = item[eventDescField.Id];
                        var eventDescText = eventDescField.GetFieldValueAsText(eventDesc);
    
                    }
                }
