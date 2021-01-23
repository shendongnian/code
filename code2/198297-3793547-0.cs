    public class Language
    {
        public int Id { get; set; }
        public string Code { get; set; }
    }
    public class CustomerModel
    {
        public Language Language { get; set; }
        public IList<Language> Languages { get; set; }
        public CustomerModel()
        {
            Language = new Language();
            Languages = new List<Language>
            {
                new Language { Id = 1, Code = "en" },
                new Language { Id = 2, Code = "fr" },
            };
        }
    }
