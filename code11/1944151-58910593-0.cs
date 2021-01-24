                using (ClientContext context = new ClientContext(sharePointSite))
                {
                    FileCreationInformation FCInfo = new FileCreationInformation();
                    FCInfo.Url = "http://sp2016/sites/dev/Shared%20Documents/Test.txt";
                    FCInfo.Overwrite = true;
                    FCInfo.Content = System.IO.File.ReadAllBytes(fileToUpload);
    
                    Web web = context.Web;
                    List library = web.Lists.GetByTitle(libraryName);
                    Microsoft.SharePoint.Client.File uploadfile = library.RootFolder.Files.Add(FCInfo);
                   
                    ListItem item = uploadfile.ListItemAllFields;
                    item["Title"] = "some data";
                    var fields = library.Fields;
                    var field = fields.GetByInternalNameOrTitle("managedcolumn");
                    context.Load(fields);
                    context.Load(field);
                    context.ExecuteQuery();
                    var taxKeywordField = context.CastTo<TaxonomyField>(field);
                    TaxonomyFieldValue termValue = new TaxonomyFieldValue();
                    termValue.Label = "TermC";
                    termValue.TermGuid = "045830f1-f51e-4bac-b631-5815a7b6125f";
                    termValue.WssId = 3;
                    taxKeywordField.SetFieldValueByValue(item, termValue);
                    item.Update();
                    context.ExecuteQuery();
    
                    uploadfile.CheckIn("testcomment", CheckinType.MajorCheckIn);
                    context.ExecuteQuery();
              
                }
