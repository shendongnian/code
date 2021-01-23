    using WatiN.Core;
    namespace Project.Extensions
    {
        public static class WatinExtensions
        {
            public static void TypeTextFaster(this TextField textfield, string value)
            {
                textfield.Value = value;
                textfield.Change();
            }
        }
    }
