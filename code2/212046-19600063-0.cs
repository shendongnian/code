    public static void lang(string lge)
            {
                System.Globalization.CultureInfo TypeOfLanguage = new    System.Globalization.CultureInfo(lge);
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(TypeOfLanguage);
            }
        
