    private string entryText;
    public string EntryText
    {
        get => entryText;
        set
        {
            if (entryText != null && value.Length < entryText.Length)
            {
                Console.WriteLine("Char was deleted");
            }
    
            SetProperty(ref entryText, value);
        }
    }
