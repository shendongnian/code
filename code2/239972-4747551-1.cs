    public void MyMethod(object Value)
    {
        List<Document> documents = null;
        if (Value is List<Document>)
        {
            documents = (List<Document>) Value;
        }
        else if (Value is Document)
        {
            documents = new List<Document>();
            documents.Add((Document) Value);
        }
    
        if (MainForm != null && documents != null)
            MainForm.BindData(documents);
    }
