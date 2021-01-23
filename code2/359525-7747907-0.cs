    poupou@mizar:~/src$ gmcs --version
    Mono C# compiler version 2.6.7.0
    poupou@mizar:~/src$ cat x.cs
    using System;
    
    class Program {
    
    	static void PrintMatrix (double[,] values)
    	{
    		Console.WriteLine ("{0}, {1}\n{2}, {3}", values [0,0], values [0,1], values [1,0], values [1,1]);
    	}
    
    	static void Main ()
    	{
    		PrintMatrix (new double[,] { {1.0, 2.0}, {3.0, 4.0} });
    	}
    }
    
    poupou@mizar:~/src$ gmcs x.cs
    poupou@mizar:~/src$ mono x.exe
    1, 2
    3, 4
