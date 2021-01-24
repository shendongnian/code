     using (SPSite site = new SPSite("http://sp/sites/jerry"))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    var list = web.Lists.TryGetList("TestList");
                    var item = list.GetItemById(1);
                    var eventDescField = list.Fields.GetFieldByInternalName("Parameters");
                    var eventDesc = item[eventDescField.Id];
                    var eventDescText = eventDescField.GetFieldValueAsHtml(eventDesc);
                    SPList word = (SPDocumentLibrary)web.Lists["Jerrydoc"];
                    
                    string destUrl = word.RootFolder.Url + "/" + "MyWord8" + ".doc";
                    // Encoding the document to UTF8 format
                    byte[] byteArray = Encoding.UTF8.GetBytes((eventDescText.ToString()));
                    SPFile destFile = word.RootFolder.Files.Add(destUrl, byteArray, true);
                }
            }
