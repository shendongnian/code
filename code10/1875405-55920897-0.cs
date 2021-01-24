    public static float parseFloat(string number)
    {
        float ishod = 0;
        try
        {
            float.TryParse(number.Replace(".", ","), out ishod);
        }
        catch(Exception ex)
        {
            ishod = float.NaN;
            Console.WriteLine("parseFloat(): " + ex.Message);
        }
        return ishod;
    } 
