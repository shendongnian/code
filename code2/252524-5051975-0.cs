    	var articlesLevel1 = (
                from al1 in Articles
                join al2 in Articles on new
                {
                        al1.ArticleIndex,
                        ArticleLevel = 2
                } equals new
                {
                        ArticleIndex = al2.ArticleParentIndex,
                        al2.ArticleLevel
                } into g_al2
                where (al1.ArticleLevel == 1) && g_al2.Any()
                select new
                {
                        ArticlesLevel1 = al1,
                        ArticlesLevel2Count = g_al2.Count()
                });
