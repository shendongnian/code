    public class MyClass
    {
        private System.Threading.Timer _MyTimer;
    public MyClass()
    {
        _MyTimer = new Timer(OnElapsed, null, 0, Timeout.Infinite);
    }
    public void OnElapsed(object state)
    {
        _MyTimer.Change(Timeout.Infinite, Timeout.Infinite);
        Console.WriteLine("I'm working");
        _MyTimer.Change(1000, Timeout.Infinite);
    }
}
