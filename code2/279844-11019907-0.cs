    // if exists delete the file 
System.IO.File.Delete("Test.sdf");
    string cnn = "Data Source = 'TestDB.sdf'; LCID=1033; Password = <ThePassword>;";
    SqlCeEngine ceEngine = new SqlCeEngine(cnn);
    ceenngine.CreateDatabase();`
