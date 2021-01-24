       class Program
        {
            static void Main(string[] args)
            {
                DataBase _context = new DataBase();
                List<ProfileSections> localisedList = new List<ProfileSections>();
                var results = (from profile in _context.ProfileSections
                               join local in localisedList on profile.Id equals local.Id
                               select new { profile = profile, local = local }
                               ).ToList()
                               .Select(p => new
                               {
                                   Id = p.profile.Id,
                                   Description = p.profile.Description,
                                   InformationText = p.profile.InformationText,
                                   TranslateDescription = p.local.TranslateDescription,
                                   TranslateInformationText = p.local.TranslateInformationText
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
