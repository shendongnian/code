    if (System.IO.File.Exists(Dts.Variables["User::ARCHIVEFILE"].Value.ToString())){
    
        lineOut = "del " + Dts.Variables["User::ARCHIVEFILE"].Value.ToString() + Environment.NewLine + "bye";
        System.IO.File.WriteAllText(File1, lineOut);
    
    }
    
    if (Dts.Variables["User::FTPFILE"].Value.ToString())){
    
        lineOut = "ren " + Dts.Variables["User::FTPFILE"].Value.ToString() + " " + Dts.Variables["User::ARCHIVEFILE"].Value.ToString() + Environment.NewLine + "bye";
        System.IO.File.WriteAllText(File2, lineOut);   
    
    }
