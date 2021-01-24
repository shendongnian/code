c#
public  class A
{
    public int id { get; set; }
    public bool isActive { get; set; }
    public List<B> BCollection { get; set; }
}
public class B
{
    public B (A a){
        isAActive = a.isActive;
        }
    public int id { get; set; }
    public A A { get; set; }
    public bool isAActive { get; set; }
}
static void Main(string[] args)
{
    A a = new A()
    {
        id = 1,
        isActive = true
    };
    A a2 = new A()
    {
        id = 2,
        isActive = false
    };
    List<B> bs = new List<B>()
    {
        new B(a) { id = 100, A = a},
        new B(a) { id = 200, A = a}
    };
    a.BCollection = bs;
    List<B> bs2 = new List<B>()
    {
        new B(a2) { id = 300, A = a2},
        new B(a2) { id = 300, A = a2}
    };
    a2.BCollection = bs2;
    return;
}
a.BCollection will have the isAActive set to true<br>
a2.BCollection will have the isAActive set to false
