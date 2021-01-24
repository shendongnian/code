    class Program
    {
        static void Main(string[] args)
        {
            System.Management.Automation.PowerShell ps = System.Management.Automation.PowerShell.Create();
            List<Microsoft.InternationalSettings.Commands.WinUserLanguage> userLangList = ps.AddCommand("Get-WinUserLanguageList").Invoke()[0].BaseObject as List<Microsoft.InternationalSettings.Commands.WinUserLanguage>;
            foreach (Microsoft.InternationalSettings.Commands.WinUserLanguage userLang in userLangList)
            {
                Console.WriteLine("{0,-31}{1,-47}", "Antonym", userLang.Autonym);
                Console.WriteLine("{0,-31}{1,-47}", "EnglishName", userLang.EnglishName);
                Console.WriteLine("{0,-31}{1,-47}", "Handwriting", userLang.Handwriting);
                Console.WriteLine("{0,-31}{1,-47}", "InputMethodTips", String.Join(",", userLang.InputMethodTips));
                Console.WriteLine("{0,-31}{1,-47}", "LanguageTag", userLang.LanguageTag);
                Console.WriteLine("{0,-31}{1,-47}", "LocalizedName", userLang.LocalizedName);
                Console.WriteLine("{0,-31}{1,-47}", "ScriptName", userLang.ScriptName);
                Console.WriteLine("{0,-31}{1,-47}", "Spellchecking", userLang.Spellchecking);
                Console.WriteLine();
            }
        }
    }
