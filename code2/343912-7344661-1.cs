    using System.Drawing;
    private string ErrorMessage(string input, int rowNr, int colNr)          
    {             
        if (!string.IsNullOrEmpty(input))
            return input;
        return  "<font color='Red'>" + "No value entered" + "</font>";
    } 
