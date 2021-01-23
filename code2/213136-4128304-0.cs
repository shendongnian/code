    public static System.Boolean FileInUse(System.String file)
    {
        try
        {
            if (!System.IO.File.Exists(file)) // The path might also be invalid.
            {
                return false;
            }
            using (System.IO.FileStream stream = new System.IO.FileStream(file, System.IO.FileMode.Open))
            {
                return false;
            }
        }
        catch
        {
            return true;
        }
    }
