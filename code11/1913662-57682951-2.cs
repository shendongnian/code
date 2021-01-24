public partial class ConnectionInfo 
{
    private string accountField;
   
    public ConnectionInfo() 
    {
        this.accountField = "FOO";
    }
    [System.ComponentModel.DefaultValueAttribute("FOO")]
    public string account 
    {
        get 
        {
            return this.accountField;
        }
        set 
        {
            this.accountField = value;
        }
    }
}
So it should be possible to get the value from that attribute, using some reflection:
    var type = typeof(ConnectionInfo);
    var prop = type.GetProperty("account");
    var attr = (DefaultValueAttribute)prop.GetCustomAttributes(
        typeof(DefaultValueAttribute), true).First();
    Console.WriteLine(attr.Value); // Will print "FOO".
As of `minOccurs` attribute, I cannot see a way to get it, other than reading the WSDL schema yourself.
