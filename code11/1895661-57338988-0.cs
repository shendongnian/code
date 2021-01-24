      //open word Document located in a specific path
        public static void openWordDocument(string fileName)
        {
            try
            {
                wordApplication = createWordApplicationObject(wordApplication);
                wordApplication.Visible = true;
                string filePath = myPath + fileName;
                WordApi.Document docx = wordApplication.Documents.Open(filePath);
            }
            catch (Exception ex)
            {
                MyLogger.Error(ex.ToString());
            }
        }
    private static WordApi.Application createWordApplicationObject(WordApi.Application wordApp)
        {
            WordApi.Application wordAppFirstTime;
            WordApi.Application wordApp1;
            if (wordApp == null)
            {
                wordAppFirstTime = new WordApi.Application();
                return wordAppFirstTime;
            }
            else
            {
                wordApp1 = new WordApi.Application();
                return wordApp1;
            }
        }
