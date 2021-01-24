c#
public YourModelNow
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Age { get; set; }
    public string Size { get; set; }
}
public YourModelNowFiltered
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
This is assuming you need two `file.json` with the different properties. If you just need to ignore the properties use Ross Gurburts approach.  
