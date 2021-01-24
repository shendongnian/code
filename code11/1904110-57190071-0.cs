// If modifying these scopes, delete your previously saved credentials
static string[] Scopes = { SheetsService.Scope.Spreadsheets }; // Full Read, Write, View Permissions
static string ApplicationName = "Tracker";
// Function that will get the credentials used for authenticating a request
public static UserCredential SetCredentials()
{
    using (var stream =
        new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
    {
        // The file token.json stores the user's access and refresh tokens, and is created
        // automatically when the authorization flow completes for the first time.
        string credPath = "token.json";
        return GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.Load(stream).Secrets,
            Scopes,
            "user",
            CancellationToken.None,
            new FileDataStore(credPath, true)).Result;
    }
}
// Function that will pull data from @spreadsheet @range
public static IList<IList<Object>> Get(UserCredential credential, string spreadsheetId, string range)
{
    var service = new SheetsService(new BaseClientService.Initializer()
    { HttpClientInitializer = credential, ApplicationName = ApplicationName, });
    SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(spreadsheetId, range);
    ValueRange response = request.Execute();
    return response.Values;
}
Then I called it like this.
IList<IList<Object>> client_sheet = Get(SetCredentials(), "SomeSpreadsheetId", "Client!A2:AY");
This function converted it into a table for my sql to handle or datagrid to bind to.
public static DataTable De2DList_Table(IList<IList<Object>> s)
{
    DataTable table = new DataTable();
    List<string> columns = new List<string>()
    {
        "Column Name", "Column Name", "Column Name", "Column Name",
        "Column Name", "Column Name", "Column Name", "Column Name",
        "Column Name", "Column Name", "Column Name", "Column Name", "Column Name", "Column Name",
        "Column Name", "Column Name", "Column Name"
    };
    foreach(var header in columns)
    {
        table.Columns.Add(header, typeof(string));
    }
    for (var i = 0; i < 4000; i++) {
        table.Rows.Add(new Object[] {
            s[i][0], s[i][1], s[i][2], s[i][3],
            s[i][4], s[i][5], s[i][6], s[i][7],
            s[i][8], s[i][9], s[i][10], s[i][11],
            s[i][12], s[i][13], s[i][14], s[i][15],
            s[i][16]
        });
    }
    return table;
}
Clears the local db, destructs the 2d list into a datatable and adds it to the database. Set's my datagrid to my sql table.
DBFunctions db = new DBFunctions();
db.executeDB("DELETE FROM Client"); // Delete everything from local database
db.loadDB(De2DList_Table(client_sheet)); // Load the database with client sheet data
JumpTable.ItemsSource = db.getDBTable("SELECT * FROM Client").DefaultView;
db.closeDBConnection();
JumpTable.AutoGenerateColumns = true;
JumpTable.CanUserAddRows = false;
