public class Timer
{
    int mStart;
    public Timer()
    {
        mStart = Now();
    }
    ~Timer()
    {
        Console.WriteLine("Elapsed Time: {0}", Now() - mStart);
    }
}
public class MainFunction
{
    public static int Main()
    {
        {
            Timer timer();
            DoSomethingWorthTimming();
        } // <-- ~Timer() is called
        {
            Timer timer();
            DoSomethingElseWorthTimming();
        } // <-- ~Timer() is called
    }
Using scope this way allows you to control when a destructor is called for an object. In this case, that allows us to time a block of code.
Hopefully that helps.
