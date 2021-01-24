C#
// Class is part of this or common library
public class AppSettings
{
    public string AppDbConnectionString { get; set; }
    // more settings
}
public class MyLib
{
    private srting _connectionString;
    // Inject settings 
    public MyLib(AppSettings settings)
    {
        _connectionString = settings.AppDbConnectionString;    
    }
}
