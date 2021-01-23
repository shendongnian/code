    MySqlConnection con = new MySqlConnection("Server=localhost;Database=bd_prueba;Uid=root;Pwd=Intel-IT;");
    FileStream fs = new FileStream(@"D:\proyectos2.jpg", FileMode.Open, FileAccess.Read);
    byte[] rawData = new byte[fs.Length];        
    fs.Read(rawData, 0, (int)fs.Length);
    fs.Close();
    //byte[] to HEX STRING
    string hex = BitConverter.ToString(rawData);
    //'F3-F5-01-A3' to 'F3F501A3'
    hex = hex.Replace("-", "");
    if(con.State == con.Closed)
    {
        con.Open();
    }
    //Standart VALUE HEX x'F3F501A3'
    string SQL = @"INSERT INTO tabla(id,fileimage) VALUES ('stringhex',x'"+hex+"')";
    MySqlCommand cmd = new MySqlCommand();
    cmd.Connection = con;            
    cmd.CommandText = SQL;
    cmd.ExecuteNonQuery();
    if(con.State == con.Open)
    {
        con.Close();
    }
