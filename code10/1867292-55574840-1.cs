    class Program
	{
	    static bool _bool;
        static void Main()
	    {
		    Task.Factory.StartNew(() => { while (true) _bool = !_bool; });
            // define a "ref local" that persistently views Boolean value '_bool' as a byte
		    ref byte _byte = ref Unsafe.As<bool, byte>(ref _bool);
		    while (true)
			    Console.Write(_byte + " ");
        }
    };
