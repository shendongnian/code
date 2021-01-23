    string query = @"SET SQL_MODE= 'NO_AUTO_VALUE_ON_ZERO'; CREATE DATABASE " + dbName + " DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci" + Environment.NewLine;
    MySqlCommand c;
    c = new MySqlCommand(query, conn);
    c.ExecuteNonQuery();
    
    using (StreamReader reader = File.OpenText("C:\b.sql"))
    {
        string line = reader.ReadToEnd();
        query = "USE " + dbName + "; " + line;
        c = new MySqlCommand(query, conn);
        c.ExecuteNonQuery();
    }
