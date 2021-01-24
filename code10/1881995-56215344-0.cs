    CyklusSAP = double.Parse(gvr.Cells[10].Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                                               //^^^^^^^^^^^^^^^^ this will convert 30,6 to 30.6
    prevod = double.TryParse(gvr.Cells[11].TextReplace(',', '.'),out CyklusReal);
    
    if(prevod && CyklusSAP > prevod )
    {
       // Your logic goes here
    }
