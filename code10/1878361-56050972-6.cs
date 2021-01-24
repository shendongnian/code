    public class RepositoryMap
    {
        public static Dictionary<string, string> ObjectToDatatableMap = new Dictionary<string, string>
        {
            // keep in mind that key is the DTO property
            // value is the datatable columm name
            {"Id", "ID"},
            {"Owner", "OWNER"},
            {"QueryName", "QUERY NAME"},
            {"PhoneNumber", "Phone Number"},
        };
    }
