    public bool CheckFileType(string FileName)
    {
        string Ext;
        try
        {
            Ext = Path.GetExtension(FileName);
        }
        catch (ArgumentException ex)
        {
            return false;
        }
        // Switch statement
    }
