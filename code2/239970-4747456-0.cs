    public void MyMethod(object Value)
        {
                            
                                var documentList = Value as List<Document>;
                                if (documentList != null)
                                {
                                   if (MainForm != null)
                                    MainForm.BindData(documentList);
                                }
                           
                                var document = Value as Document;
                                if (document != null)
                                 { 
                                if (MainForm != null)
                                    MainForm.BindData(document);
                                 }
    }
