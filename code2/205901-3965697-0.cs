    private string YourMethod()
    {
        var sb = new StringBuilder();
        try
        {
            // Do your stuff
        }
        catch (ASpecificException ex)
        {
            sb.Insert(0, ex.Message);
        }
        finally
        {
            sb.Append("YourFooter");
        }
        return sb.ToString();
    }
