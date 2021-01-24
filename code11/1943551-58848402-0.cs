c-sharp
static String connString = ConfigurationManager.ConnectionStrings["Data Source=EVEDELL17;Initial Catalog=College;Integrated Security=True"].ConnectionString;
static SqlConnection myConn = new SqlConnection(connString);
static System.Data.SqlClient.SqlCommand cmdString = new System.Data.SqlClient.SqlCommand();
Those initializers will run the first time their containing class (`frmSearch`) is "touched" by the runtime. Because they aren't in a method, it's hard for the compiler to give a helpful stack trace when they fail. Try replacing the inline initializers with a static constructor:
c-sharp
static String connString;
static SqlConnection myConn;
static System.Data.SqlClient.SqlCommand cmdString;
static frmSearch() {
    connString = ConfigurationManager.ConnectionStrings["Data Source=EVEDELL17;Initial Catalog=College;Integrated Security=True"].ConnectionString;
    myConn = new SqlConnection(connString);
    cmdString = new System.Data.SqlClient.SqlCommand();
}
I think you'll get a better error message that way. You can also set a breakpoint in the constructor to see exactly what happens during initialization.
Read more here: https://docs.microsoft.com/en-us/dotnet/api/system.typeinitializationexception?view=netframework-4.8#Static
