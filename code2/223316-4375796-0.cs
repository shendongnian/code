    using System.Linq;
    ...
    
    public string GetAllPrimaryKeyTableNames(string localServer, string userName, string password, string selectedDatabase) {
        DataTable table = GetAllPrimaryKeyTables(localServer, userName, password, selectedDatabase);
        return string.Join(",", table.AsEnumerable().Select(r => r.ItemArray[0]).ToArray());
    }
