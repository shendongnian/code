    using System.IO;
    using System.Linq;
    using Npoi.Mapper;
    using Npoi.Mapper.Attributes;
    using NPOI.SS.UserModel;
    
    namespace JobCustomerImport.Processors
    {
        public class ExcelEmailProcessor
        {
            private UserManagementServiceContext DataContext { get; }
    
            public ExcelEmailProcessor(int customerNumber)
            {
                DataContext = new UserManagementServiceContext();
            }
    
            public void Execute(string localPath, int sheetIndex)
            {
                IWorkbook workbook;
                using (FileStream file = new FileStream(localPath, FileMode.Open, FileAccess.Read))
                {
                    workbook = WorkbookFactory.Create(file);
                }
    
                var importer = new Mapper(workbook);
                var items = importer.Take<MurphyExcelFormat>(sheetIndex);
                foreach(var item in items)
                {
                    var row = item.Value;
                    if (string.IsNullOrEmpty(row.EmailAddress))
                        continue;
    
                    UpdateUser(row);
                }
    
                DataContext.SaveChanges();
            }
    
            private void UpdateUser(MurphyExcelFormat row)
            {
                //LOGIC HERE TO UPDATE A USER IN DATABASE...
            }
    
            private class MurphyExcelFormat
            {
                [Column("District")]
                public int District { get; set; }
    
                [Column("DM")]
                public string FullName { get; set; }
    
                [Column("Email Address")]
                public string EmailAddress { get; set; }
    
                [Column(3)]
                public string Username { get; set; }
    
                public string FirstName
                {
                    get
                    {
                        return Username.Split('.')[0];
                    }
                }
    
                public string LastName
                {
                    get
                    {
                        return Username.Split('.')[1];
                    }
                }
            }
        }
    }
