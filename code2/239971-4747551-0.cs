    public void MyMethod(object Value)
    {
        List<Document> documents = Value as List<Document>;
        if (Value is Document)
        {
            documents = new List<Document>();
            documents.Add((Document) Value);
        }
    
        if (MainForm != null && documents != null)
            MainForm.BindData(documents);
    }
