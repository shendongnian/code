    using static System.Environment;
       
    FirmNames = "";
    foreach (var item in FirmNameList)
    {
        if (FirmNames != "")
        {
           FirmNames += ", " + NewLine;
        }
        FirmNames += item;
    }
