    private string entryText;
    public string EntryText
    {
        get => entryText;
        set
        {
            if (!string.IsNullOrEmpty(entryText) && value.Length < entryText.Length)
            {
                Console.WriteLine("Char was deleted");
            }
    
            SetProperty(ref entryText, value);
        }
    }
