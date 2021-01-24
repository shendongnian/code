`csharp
for(int i = 0; i < ThreadCount; i++)
{
    int ii = i; // copy value of i to temp variable
    Thread t = new Thread(() => 
    { 
        Console.Write(ii); }); 
        threads[ii] = t;
    }
}
`
