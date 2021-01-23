    public bool CheckFileType(string FileName)
    {
        try
        {
            string Ext = Path.GetExtension(FileName).ToLower();
            string[] okExt = ".gif|.jpg|.jpeg|.png|.bmp".Split('|');
            foreach(var item in okExt)
            {
                if(Ext == item)
                    return true;
            }
            return false;
        }
        catch(Exception ex)
        {
            throw;
        }
    }
