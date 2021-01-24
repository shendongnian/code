    static void Main(string[] args)
        {
            string path = @"C:\Documents";
            MonitorDirectory(path);
            Console.ReadKey();
        }
        private static void MonitorDirectory(string path)
        {
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
            fileSystemWatcher.Path = path;
            fileSystemWatcher.Created += FileSystemWatcher_Created;
            fileSystemWatcher.EnableRaisingEvents = true;
        }
        private static void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File created: {0}", e.Name);
            string connectionString = @"Data Source=Development-PC\SQLEXPRESS;Initial Catalog=FileDB;Integrated Security=True";
            FileInfo info = new FileInfo(e.FullPath);
            byte[] file;
            //only needed if you are saving file content
            using (var fileStream = File.OpenRead(e.FullPath))
            {
                BinaryReader reader = new BinaryReader(fileStream);
                file = reader.ReadBytes((int)fileStream.Length);
            }
            DateTime dateTimeVariable = DateTime.Now;
            SqlCommand command;
            SqlConnection connection = new SqlConnection(connectionString);
            command = new SqlCommand("INSERT INTO FileTable (filename, datestamp) VALUES (@filename,  @datestamp)", connection);
            command.Parameters.Add("@filename", SqlDbType.NVarChar).Value = info.Name;
            //command.Parameters.Add("@filecontent", SqlDbType.Binary).Value = file;//needed if you are saving file content
            command.Parameters.Add("@datestamp", SqlDbType.DateTime).Value = dateTimeVariable;
            connection.Open();
            command.ExecuteNonQuery();
        }
 
