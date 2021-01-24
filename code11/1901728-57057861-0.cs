    public class ExcelReader<T> where T : Enum
    {
        internal Dictionary<T, StorageFile> ExcelDataFiles { get; set; }
        internal async Task SetupExcelFiles(Dictionary<T, string> fileKeyNames, StorageFolder filesDirectory)
        {
            //code sample here
        }
    }
