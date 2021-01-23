    public class Translator
    {
        private ITranslator translatorInstance;
    
        public Translator()
        {
            SomeContainer container = SomeContainer.CreateFromConfig(configFilePath);
    
            // this is the ONLY point we touch the container
            translatorInstance = container.GetMeA<ITranslator>();
        }
    
        // implementation
    }
