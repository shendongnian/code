    for (int i = ArticleList.Count -1; i >= 0; i--)
    {
        for (int j = 0; j < listWriters.Count; j++)
        {
            if (ArticleList[i].WriterId == listWriters[j].WriterID )
                ArticleList.RemoveAt(i);
        }            
    }
