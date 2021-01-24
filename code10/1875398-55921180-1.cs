        class Program
        {
            static void Main(string[] args)
            {
                DataBase _context = new DataBase();
                List<ProfileSections> localisedList = new List<ProfileSections>();
                var results = localisedList  
                               .Select(p => new
                               {
                                   Id = p.Id,
                                   Description = p.Description,
                                   InformationText = p.InformationText,
                                   TranslateDescription = p.TranslateDescription,
                                   TranslateInformationText = p.TranslateInformationText
                               }).ToList();
            }
        }
        public class DataBase
        {
            public List<ProfileSections> ProfileSections { get; set; }
        }
        public class ProfileSections
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public string InformationText { get; set; }
            public string TranslateInformationText
            {
                get { return TranslateFunction(InformationText); }
                set { ;}
            }
            public string TranslateDescription
            {
                get { return TranslateFunction(Description); }
                set { ;}
            }
            private string TranslateFunction(string s)
            {
                return s;
            }
        }
     
