    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MySql.Data.MySqlClient;
    using System.IO;
    
    namespace MySQLHelperTest
    {
        public class MySQLTestingQuery
        {
            public MySqlConnection MyConnection { get; set; }
            public string FileSql { get; set; }
            public List<string> PreviousQuerys { get; set; }
            public List<string> CorrectQuerys { get; private set; }
            public string ErrorQuery { get; private set; }
    
            public MySQLTestingQuery()
            {
                this.CorrectQuerys = new List<string>();
                this.ErrorQuery = string.Empty;
            }
    
        public void Start()
        {
            FileInfo file = new FileInfo(this.FileSql);
            if (!file.Exists)
                throw new ApplicationException(string.Format("nonexistent file: '{0}'", this.FileSql));
            if (this.PreviousQuerys != null)
                foreach (string command in this.PreviousQuerys)
                    this.RunMySQLCommand(command);
            try
            {
                foreach (string command in this.ReadQuerys(this.FileSql))
                    Console.WriteLine(command);
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("an unexpected error happened: {0}. ", ex.Message));
            }
        }
    
            private void RunMySQLCommand(string command)
            {
                try
                {
                    using (MySqlCommand c = new MySqlCommand(command, this.MyConnection))
                    {
                        c.ExecuteReader();
                        this.CorrectQuerys.Add(command);
                    }
                }
                catch (Exception ex)
                {
                    this.ErrorQuery = command;
                    throw new ApplicationException(string.Format("error: {0}. command: {1}", ex.Message, command));
                }
            }
    
            private IEnumerable<string> ReadQuerys(string file)
            {
                using (StreamReader sr = new StreamReader(file)) 
                {
                    string query = string.Empty;
                    while (sr.Peek() >= 0)
                    {
                        query += (char)sr.Read();
                        if (query.EndsWith(";"))
                        {
                            yield return query;
                            query = string.Empty;
                        }
                    }
                }
            }
    
        }
    }
