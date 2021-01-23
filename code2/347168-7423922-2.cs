    public class ArticleComparer : IComparer<Article>
    {
        public bool Accending { get; set; }
    
        public int Compare(Article x, Article y)
        {
            float result = x.Popularity - y.Popularity;
    
            if (!Accending) { result *= -1; }
    
            if (result == 0) { return 0; }
            if (result > 0) return 1;
            return -1;
        }
    }
