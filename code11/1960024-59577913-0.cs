c#
public static void ParseIniData()
{
    var parser = new StreamIniDataParser();
    dbcReader = new StreamReader(_Assembly.GetManifestResourceStream("NewsEditor.Resources.dbc.ini"));
            
    IniData data = parser.ReadData(dbcReader);
    mysqlHost = data["Db"]["host"];
    mysqlPort = data["Db"]["port"];
    mysqlDb = data["Db"]["db"];
    mysqlUser = data["Db"]["user"];
    mysqlPwd = data["Db"]["password"];
}
where `_Assembly` is a private static attribute: ` private static Assembly _Assembly = Assembly.GetExecutingAssembly();`. This gets you the assembly that's being executed when running the code (you could also use this code directly in the method, but I used the Assembly on another method in my class, so I decided to set an attribute... DRY I guess).
