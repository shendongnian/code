    List<string> query = new List<string>(){
            "SET SQL_MODE= 'NO_AUTO_VALUE_ON_ZERO';",
            string.Format("CREATE DATABASE `{0}` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;", dbName),
            string.Format("USE `{0}`;", dbName)}; // error string.Format("USE `{0}`;{1}", dbName)
    /*    
    using (StreamReader reader = File.OpenText("C:\b.sql"))
    {
        while (reader.Peek() >= 0)
            query.Add(reader.ReadLine());
    }
    */
    using (StreamReader reader = File.OpenText("C:\b.sql"))
    {
        string lines = reader.ReadToEnd();
        string[] alines = lines.Split(';');
        foreach(string q in alines) 
                query.Add(q);
    }
        
    foreach (string command in query)
    {
        try
        {
            using (MySqlCommand c = new MySqlCommand(command, conn))
            {
                c.ExecuteReader();
                Console.WriteLine(string.Format("OK Command: {0}", command));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("Error: {0}. Command: {1}", ex.Message, command));
            break;
        }
    }
