    public IList<DocumentListItemModel> ExecuteQuery()
    {
        ArticleReference articleReferenceAlias = null;
        return Session
            .QueryOver<Document>()
            .JoinAlias(n => n.ArticleReferences, () => articleReferenceAlias,
                JoinType.LeftOuterJoin)
            .SelectList(list => list
                .Select(n => n.Id)
                .Select(n => articleReferenceAlias.Number))
            .List<object[]>()
            .Select(x => new
            {
                Id = (int)x[0],
                ArticleNumber = (string)x[1]
            })
            .GroupBy(n => n.Id).Select(n =>
            {
                return new DocumentListItemModel
                {
                    Id = n.First().Id,
                    ArticleNumbers = string.Join(", ", n.Select(p => p.ArticleNumber))
                };
            }).ToList();
        }
    }
