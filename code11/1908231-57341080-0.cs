    private void RunIt()
    {
        string tessDataPath = yourTessDataPath; // Your Tesseract Location Set
        string imagePath = yourImagePath; // The Image File Location
        string theTextFromTheImage = DoOCR(yourTessDataPath, yourImagePath);
        // Some formatting may be required - OCR isn't perfect
        MessageBox.Show(theTextFromTheImage);
    }
    private string DoOCR(string tessdataPath, string filePath)
    {
        string returnText = "";
        using (var engine = new TesseractEngine(tessdataPath, "eng", EngineMode.Default))
        {
            // engine.SetVariable("tessedit_char_whitelist", "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"); // Only regular letters
            string theVersion = engine.Version; // Optional, but useful
            using (var img = Pix.LoadFromFile(filePath))
            {
                using (var page = engine.Process(img))
                {
                    returnText = page.GetText();
    
                }
            }
        }
        return returnText;
    }
