public class Cars
{
    public int intValue { get; set; }
    public string stringValue { get; set; }
    public bool worked { get; set; }
}
public Cars GetCar(int value, Cars c)
{
    c.intValue = value;
    return c;
}
public Cars GetCar(string value, Cars c)
{
    c.stringValue = value;
    return c;
}
public void Main(string[] args)
{
    Cars c = new Cars();
    string mycar = "ABC-12";
    int mycar2 = 123;
    if (GetCar(mycar, c).stringValue == "ABC")
        GetCar(mycar, c).worked = false;
    if (GetCar(mycar2, c).intValue == 1)
        GetCar(mycar2, c).worked = false;
}
This will work, but it's not a nice solution. I need more info about the project to be able to create a good design.
