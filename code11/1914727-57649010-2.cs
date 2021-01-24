    public static class CsvFormatFunctions
    {
        public static object[] GetArticleValues(Article article)
        {
            return new object[]
            {
                $"\"{article.ArticleName}\"",
                $"\"{article.Price}\"",
                $"\"{article.ArticleType}\"",
                $"{(article.Active == true ? "Active" : "Inactive")}"
            });
        }
    }
