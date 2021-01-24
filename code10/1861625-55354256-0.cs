        class Program
        {
            static void Main(string[] args)
            {
                string technoName = "abc";
                UserManager _userManager = new UserManager();
                AppUser appUser = new AppUser() { Users = _userManager.Users.ToList() };
                var users = appUser.Users.SelectMany(x => x.Languages.Where(y => y.LanguageName.Name == technoName)).ToList();
     
            }
     
        }
        public class AppUser
        {
            public List<UsersData> Users { get; set; }
        }
        public class UserManager
        {
            public List<UsersData> Users { get; set; }
        }
        public class UsersData
        {
            public Guid Id { get; set; }
            //public Gender Gender { get; set; }
            //public City City { get; set; }
            //public Company Company { get; set; }
            //public Line Line { get; set; }
            //public Area Area { get; set; }
            //public List<AcademicRecord> AcademicRecords { get; set; }
            //public List<MasterPostgraduate> MasterPostgraduates { get; set; }
            public List<Language> Languages { get; set; }
            //public List<Technology> Technologies { get; set; }
            //public List<Project> Projects { get; set; }
            //public List<ProfessionalRecord> ProfessionalRecords { get; set; }
        }
        public class Language
        {
            public Guid Id { get; set; }
            public LanguageName LanguageName { get; set; }
            //public CertificationFile CertificationFile { get; set; }
            public int WritingLevel { get; set; }
            public int SpeakingLevel { get; set; }
            public int CertificationLevel { get; set; }
            public string CertificationName { get; set; }
            public DateTime CertificationDate { get; set; }
            public UsersData UserInfo { get; set; }
        }
        public class LanguageName
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
