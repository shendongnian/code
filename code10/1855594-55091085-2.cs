class Program
{
    static void Main(string[] args)
    {
        var pub = new PublicClass();
        // If PrivateClass was public we could do this
        //var priv = new PublicClass.PrivateClass(pub);
        //priv.ChangeX(3);
    }
}
public class PublicClass
{
    private int _x;
    private readonly PrivateClass _privateClass;
    public PublicClass() => _privateClass = new PrivateClass(this);
    private class PrivateClass
    {
        private readonly PublicClass _publicClass;
        public PrivateClass(PublicClass publicClass)
        {
            _publicClass = publicClass;
            ChangeX(2);
        }
        // We can access our parents class's private members
        public void ChangeX(int newX) => _publicClass._x = newX;
    }
}
