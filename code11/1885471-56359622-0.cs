       public class User
       {
           public int Id { get; set; }
           public string FirstName { get; set; }
           public string LastName { get; set; }
           [ForeignKey("OrigLanguage")]
           public int OrigLanguageId { get; set; }
           [ForeignKey("Language")]
           public int LanguageId { get; set; }
           public Language OrigLanguage { get; set; }
           public Language Language { get; set; }
       }
