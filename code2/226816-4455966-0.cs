        class Program {
        public const int NotSet = 1;
        public const int Anonymous = 1 << 2;
        public const int Everyone = 1 << 3;
        public const int Adult = 1 << 4;
        public const int Child = 1 << 5;
        public const int LikesFishing = 1 << 6;
        public static bool HasFlag(Article article, int flag) {
            return (article.Targets & flag) != 0;
        }
        public static bool HasFlags(Article article, params int[] flags) {
            foreach (int flag in flags) {
                if ((article.Targets & flag) == 0) return false;
            }
            return true;
        }
        static void Main(string[] args) {
            var article1 = new Article() {
                Title = "Announcement for Parents and Children",
                Targets = Adult | Child
            };
            var article2 = new Article() {
                Title = "What fishing boat do you own?",
                Targets = LikesFishing | Adult
            };
            var article3 = new Article() {
                Title = "Be nice to your parents!",
                Targets = Child
            };
            List<Article> db = new List<Article>() { article1, article2, article3 };
            var articles =
                db.Where(x => HasFlag(x, LikesFishing));
            foreach (Article article in articles) {
                Console.WriteLine(article.Title);
            }
        }
    }
    class Article {
        public string Title { get; set; }
        public int Targets { get; set; }
    }
