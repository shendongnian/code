    public static string GetEmailTemplateContent(string path)
    {
        string emailHtmlTemplate = "";
        StreamReader rdr = null;
        try
        {
            rdr = new StreamReader(path);
            emailHtmlTemplate = rdr.ReadToEnd();
        }
        catch (IOException ex)
        {
            throw new Exception(ex.Message.ToString());
        }
        finally
        {
            if (rdr != null)
            {
                rdr.Close();
                rdr.Dispose();
            }
        }
        return emailHtmlTemplate;
    }
