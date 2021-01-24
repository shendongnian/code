`
public void XYZ()
{
    Stopwatch sw = new Stopwatch();
    sw.Start();
    for (int i = 0; i < 1000000; i++)
    {
        someFunction("some string");
    }
    sw.Stop();
    Debug.WriteLine(sw.ElapsedMilliseconds);
    sw.Reset();
    sw.Start();
    for (int i = 0; i < 1000000; i++)
    {
        someFunction("$some string");
    }
    sw.Stop();
    Debug.WriteLine(sw.ElapsedMilliseconds);
    sw.Reset();
    sw.Start();
    for (int i = 0; i < 1000000; i++)
    {
        someFunction(string.Format("some string"));
    }
    sw.Stop();
    Debug.WriteLine(sw.ElapsedMilliseconds);
    sw.Reset();
}
private void someFunction(string param)
{
}
`
gives me 
`
3
3
210
`
So, do not use string.Format() if you don't have to :-)
