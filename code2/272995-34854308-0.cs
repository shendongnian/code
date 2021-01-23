    using System.Text.RegularExpressions;
    var regexColorCode = new Regex("^#[a-fA-F0-9]{6}$");
    string colorCode = "#FFFF00";
    if (!regexColorCode.IsMatch(colorCode.Trim()))
    {   
        ScriptManager.RegisterStartupScript(this, GetType(), "showalert" ,"alert('Enter a valid Color Code');", true);
    }
    else
    {
        //do your thing
    }
