    using (SftpClient sftp = new SftpClient(host, username, password))
      {
          sftp.Connect();
        
          try
          {
              using (Stream fileStream = File.OpenWrite(pathLocalFile))
              {
                using (var reader = new StreamReader(fileStream))
                {
                  using (var csv = new CsvReader(reader))
                  {
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
                  }
                }
              }          
          }
          finally {
            sftp.Disconnect();
          }
      }
