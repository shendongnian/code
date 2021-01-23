    class Program
    {
        static void Main()
        {
            sbyte[] signedByteArray = { -2, -1, 0, 1, 2 };
            byte[] unsignedByteArray = (byte[])(Array)signedByteArray; 
            Console.WriteLine(Convert.ToBase64String(unsignedByteArray));
        }
    }
