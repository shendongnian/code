 c#
for (int i = 0; i < soThread; i++)
{
    int copy = numnum;
    Thread threadnew = new Thread(delegate ()
    {
        //Console.WriteLine(copy);
        Number(copy);
    });
    // ...
}
