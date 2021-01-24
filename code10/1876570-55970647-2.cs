    public static bool TryDeleteFile(string filePath)
    {
        try
        {
            FileInfo fi = new FileInfo(filePath);
            if (fi.IsReadOnly)
            {
                fi.IsReadOnly = false;
            }
            fi.Delete();
            return true;
        }
        catch (FileNotFoundException)
        {
            return true;
        }
        catch (Exception ex)
        {
            // Log Exception
            return false;
        }
    }
