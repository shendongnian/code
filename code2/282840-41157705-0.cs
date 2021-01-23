    string sPipeSplit = "This|is|a|pip\\|ed|test (this is a pip|ed test)";
    string sTempString = sPipeSplit.Replace("\\|", "¬"); //replace \| with non printable character
    string[] sSplitString = sTempString.Split('|');
    //string sFirstString = sSplitString[0].Replace("¬", "\\|"); //If you have fixed number of fields and you are copying to other field use replace while copying to other field.
    /* Or you could use a loop to replace everything at once
    foreach (string si in sSplitString)
    {
        si.Replace("¬", "\\|");
    }
    */
