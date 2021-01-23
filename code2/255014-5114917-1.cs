internal class Program
{
    // Methods
    protected bool callback(int a)
    {
        return true;
    }
    public void Entrance()
    {
        ABC a = new ABC();
        a.eventX += new ABC.X(this.callback);
    }
    private static void Main(string[] args)
    {
        new Program().Entrance();
    }
}
 
