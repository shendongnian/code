    namespace StructureMapTests
    {
        public interface ITranslator
        {
        }
    
        public enum BrowserType
        {
            IE,
            Firefox,
            Chrome
        }
    
        public class Translator : ITranslator
        {
            public Translator(BrowserType browserType)
            {
                
            }
        }
    }
