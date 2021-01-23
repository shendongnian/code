public class Cake
{
    private int _id;
    private string _name;
    private static int LastID;
    public Cake(string name)
    {
        _name = name;
        _id = LastID++;
    }
    public int GetID()
    {
        return _id;
    }
}
