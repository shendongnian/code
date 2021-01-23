    // Read in the template file
    string fileSql = System.File.IO.ReadAllText(pathToYourTemplateFile)
    
    // Replace the place holders with your values (sample assumes
    // they are coming from textboxes on the UI
    string formattedSql = string.Format(fileSql,
        txtServerName.Text,
        txtUid.Text,
        txtPassword.Text);
    
    // Write out the new file
    System.IO.File.WriteAllText(formattedSql, pathToYourNewFile);
