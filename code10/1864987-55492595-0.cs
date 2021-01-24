    using System.Text.RegularExpressions;
    
    string checkPanNo = @"^[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}$";
    bool isPANValid = Regex.IsMatch(txtPanNo.Text.ToString().Trim(), checkPanNo);
    if (isPANValid == true)
    {
         //valid pan number
    }
    else 
    {
        //invalid pan number
    }
