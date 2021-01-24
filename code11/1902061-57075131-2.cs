    public Language
    {
        English,
        Turkish,
        Latin
    }
    private Dictionary<Language, string>() titles;
    private Language curentLanguage;
    // or wherever you want to initialize it
    private void Awake()
    {
         titles = new Dictionary<Language, string>()
         {
             {Language.English, currentPart.EnglishTitle}
             {Language.Turkish, currentPart.TurkishTitle}
             {Language.Latin, currentPart.LatinTitle}
         }
         turkishButton.onClick.AddListener(()=>{curentLanguage = Language.Turkish;})
         englishButton.onClick.AddListener(()=>{curentLanguage = Language.English;})
         latinButton.onClick.AddListener(()=>{curentLanguage = Language.Latin;})
    }
    
