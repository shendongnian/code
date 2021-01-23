    public static class Pluralizer
    {
        private static object _pluralizer;
        private static MethodInfo _pluralizationMethod;
        public static string Pluralize(string word)
        {
            CreatePluralizer();
            return (string) _pluralizationMethod.Invoke(_pluralizer, new object[] {word});
        }
        public static void CreatePluralizer()
        {
            if (_pluralizer == null)
            {
                var aseembly = typeof (DbContext).Assembly;
                var type =
                    aseembly.GetType(
                        "System.Data.Entity.ModelConfiguration.Design.PluralizationServices.EnglishPluralizationService");
                _pluralizer = Activator.CreateInstance(type, true);
                _pluralizationMethod = _pluralizer.GetType().GetMethod("Pluralize");
            }
        }
    }
