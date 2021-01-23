    using (var connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BlankDatabase.mdb"))
    {
        connection.Open();
        // Create table
        using (var command = connection.CreateCommand())
        {
            command.CommandText = @"
                CREATE TABLE FileTable (
                    FileName VARCHAR(255),
                    File IMAGE)
                ";
            command.ExecuteNonQuery();
        }
        var imageContent = File.ReadAllBytes(@"C:\logo.png");
        // upload image to the table
        using (var command = connection.CreateCommand())
        {
            command.CommandText = @"
                INSERT INTO FileTable (FileName, File)
                VALUES (@FileName, @File)
                ";
            command.Parameters.AddWithValue("@FileName", "Logo");
            command.Parameters.AddWithValue("@File", imageContent);
            command.ExecuteNonQuery();
        }
        // retreive image from the table
        using (var command = connection.CreateCommand())
        {
            command.CommandText = @"
                SELECT File
                FROM FileTable
                WHERE FileName = 'Logo'
                ";
            var readImageContent = (byte[])command.ExecuteScalar();
            File.WriteAllBytes(@"C:\logo1.png", readImageContent);
        }
        // alter image from the table
        using (var command = connection.CreateCommand())
        {
            command.CommandText = @"
                UPDATE FileTable
                SET File = @File
                WHERE FileName = 'Logo'
                ";
            command.Parameters.AddWithValue("@File", imageContent);
            command.ExecuteNonQuery();
        }
        // delete image from the table
        using (var command = connection.CreateCommand())
        {
            command.CommandText = @"
                DELETE FROM FileTable
                WHERE FileName = 'Logo'
                ";
            command.ExecuteNonQuery();
        }
    }
