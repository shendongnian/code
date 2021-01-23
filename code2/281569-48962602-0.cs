    public class Person
    {
        public IProfession Profession { get; set; }
    }
    public interface IProfession
    {
        string JobTitle { get; }
    }
    public class Programming : IProfession
    {
        public string JobTitle => "Software Developer";
        public string FavoriteLanguage { get; set; }
    }
    public class Writing : IProfession
    {
        public string JobTitle => "Copywriter";
        public string FavoriteWord { get; set; }
    }
    public class Samples
    {
        public static Person GetProgrammer()
        {
            return new Person()
            {
                Profession = new Programming()
                {
                    FavoriteLanguage = "C#"
                }
            };
        }
    }
