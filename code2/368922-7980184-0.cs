    class TestRegularExpressionValidation
{
    static void Main()
    {
        string[] numbers = 
        {
            "123-456-7890", 
            "444-234-22450", 
            "690-203-6578", 
            "146-893-232",
            "146-839-2322",
            "4007-295-1111", 
            "407-295-1111", 
            "407-2-5555", 
        };
        string sPattern = "^\\d{3}-\\d{3}-\\d{4}$";
        foreach (string s in numbers)
        {
            System.Console.Write("{0,14}", s);
            if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern))
            {
                System.Console.WriteLine(" - valid");
            }
            else
            {
                System.Console.WriteLine(" - invalid");
            }
        }
    }
