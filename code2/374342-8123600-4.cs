abstract class BaseThread
{
    private Thread _thread;
    protected BaseThread()
    {
        _thread = new Thread(new ThreadStart(this.RunThread));
    }
    // Thread methods / properties
    public void Start() => _thread.Start();
    public void Join() => _thread.Join();
    public bool IsAlive => _thread.IsAlive;
    // Override in base class
    public abstract void RunThread();
}
public MyThread : BaseThread
{
    public MyThread()
        : base()
    {
    }
    public override void RunThread()
    {
        // Do some stuff
    }
}
You get the idea.
[1]:http://en.wikipedia.org/wiki/Object_composition
