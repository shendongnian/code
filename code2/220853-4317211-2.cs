    // Read in the template file
    string fileSql = System.File.IO.ReadAllText(pathToYourTemplateFile)
    // Replace the values with the input from the UI
    fileSql.Replace("AABB1089\abcWORKSS_STO", txtServer.Text)
    // ... same for uid ...
    // ... same for pwd ...
    // Write out the new file
    System.IO.File.WriteAllText(fileSql , pathToYourNewFile);
