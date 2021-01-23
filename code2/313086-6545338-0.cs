    List<Document> FoundDocs = new List<Documents();
    Queue<Document> DocsToSearch = new Queue<Document>();
    DocsToSearch.Enqueue(StartDoc);
    while(DocsToSearch.Count != 0)
    {
        Document Doc = DocsToSearch.Dequeue();
        if(!FoundDocs.Contains(Doc))
        {
            FoundDocs.Add(Doc);
            foreach(var ChildDoc in Doc.Children)
            {
                DocsToSearch.Enqueue(ChildDoc);
            }
        }
    }
