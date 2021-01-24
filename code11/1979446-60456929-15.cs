    class Program
    {
          
        static void Main(string[] args)
        {
            string plainText = "plain text";
            string password = "password";
            string encrypted = AesManager.EncryptToBase64(plainText, password);
            Console.WriteLine(AesManager.DecryptFromBase64(encrypted, password));
            Console.ReadLine();
        }
    }
