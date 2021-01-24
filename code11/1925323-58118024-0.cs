csharp
using MongoDB.Entities;
namespace StackOverflow
{
    public class Program
    {
        public class Account : Entity
        {
            public string Name { get; set; }
            public Settings Settings { get; set; }
        }
        public class Settings
        {
            public string[] SelectedSectionIDs { get; set; }
            public string[] SectionColors { get; set; }
        }
        private static void Main(string[] args)
        {
            new DB("test", "127.0.0.1");
            var acc1 = new Account
            {
                Name = "Account One",
                Settings = new Settings
                {
                    SectionColors = new[] { "green", "red" },
                    SelectedSectionIDs = new[] { "xxx", "yyy" }
                }
            }; acc1.Save();
            var acc2 = new Account
            {
                Name = "Account Two",
                Settings = null
            }; acc2.Save();
            DB.Update<Account>()
              .Match(a => a.Settings == null)
              .Modify(a => a.Settings, new Settings())
              .AddToQueue()
              .Match(_ => true)
              .Modify(a => a.Settings.SelectedSectionIDs, new[] { "aaa", "bbb" })
              .AddToQueue()
              .Execute();
        }
    }
}
