    using (var sftp = new SftpClient(host, username, password))
    {
        sftp.Connect();
    
        try
        {
            using (var remoteFileStream = sftp.OpenRead("your_file.txt"))
            {
                using (var reader = new StreamReader(remoteFileStream))
                {
                    using (var csv = new CsvReader(reader))
                    {
                        /*
                        // Example of CSV parsing:
                        var records = new List<Foo>();
                        csv.Read();
                        csv.ReadHeader();
                        while (csv.Read())
                        {
                            var record = new Foo
                            {
                                Id = csv.GetField<int>("Id"),
                                Name = csv.GetField("Name")
                            };
                            records.Add(record);
                        }
                        */
                    }
                }
            }
        }
        finally {
            sftp.Disconnect();
        }
    }
