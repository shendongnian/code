    public static ObservableCollection<Article> GetArticles()
        {
    
            var articles = new ObservableCollection<Article>();
            foreach (string file in Directory.GetFiles("articles", "*.json", SearchOption.AllDirectories))
            {
                File.OpenText(file);
                articles.Add(JsonConvert.DeserializeObject<Article>(File.ReadAllText(file)));
            }
            return articles;
        }
