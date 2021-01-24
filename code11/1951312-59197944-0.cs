    using System;
    using System.Data.Entity;
    using System.Data.SqlServerCe;
    using System.IO;
    
    namespace WritersApp.Entities
    {
        public class WriterAppContext : DbContext
        {
            public WriterAppContext() : base(GetConnectionString()) { }
    
            private static string GetConnectionString()
            {
                var strCount = (", Password = 'writerapp'").Length;
                var _conStr = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseEntities"].ConnectionString;
                var _conString = _conStr.Replace("%APPDATA%", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                var trimToFile = _conString.Remove(_conString.Length - strCount, strCount);
    
                if (File.Exists(trimToFile)) return _conStr;
    
                SqlCeEngine en = new SqlCeEngine(_conString);
    
                en.CreateDatabase();
                return _conStr;
    
    
            }
    
            public DbSet<Notification> Notifications { get; set; }
        }
    
    
    }
