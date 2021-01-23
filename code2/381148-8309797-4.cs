    var a = from page in rowData
            select new {
                SubjectId = Page.PartitionKey.Substring(0,2),
                BookId = Page.PartitionKey.Substring(2,6),
                ChapterId = Page.PartitionKey.Substring(8)
            } into split
            group split by split.SubjectId into g
            select new {
                SubjectId = g.Key,
                Books = g.GroupBy(x => x.BookId).Count(),
                Chapters = g.GroupBy(x => x.ChapterId).Count(),
                Pages = g.Count()
            };
