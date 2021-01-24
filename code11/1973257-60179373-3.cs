List<NewsList> newsList = 
            (from n in db.News.Where(mn => mn.NewsDate == newsDate)
                    join ni in db.NewsImages.Where(mni => mni.FileOrder == 10 || mni.FileName == null)
                        on n.NewsGuid equals ni.NewsGuid into nni
                    from sublist in nni.DefaultIfEmpty()
                    orderby n.NewsDate descending
                    select new NewsList
                    {
                        NewsGuid = n.NewsGuid,
                        Heading = n.Heading,
                        FileName = sublist.FileName
                    }).Take(10).ToList<NewsList>()
