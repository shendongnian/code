    public void MyMethod(List<Document> documentList)
    {
       if (MainForm != null)
         MainForm.BindData(documentList);
    }
    public void MyMethod(Document document)
    {       
       if (MainForm != null)
         MainForm.BindData(document);
    }
