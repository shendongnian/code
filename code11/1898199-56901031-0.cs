    public class Program
    {
        public static void Main(string[] args)
        {
           System.Uri foo1 = new Uri("foo.bar.com:5678");
            int port1 = foo1.Port;  // it will return -1 as no protocol specified.
            System.Uri foo2 = new Uri("http://foo.bar.com:5678");
            int port2 = foo2.Port;  // it will return 5678
            System.Uri foo3 = new Uri("ftp://foo.bar.com:5678");
            int port3 = foo3.Port;  // it will return 5678
            System.Uri foo4 = new Uri("https://foo.bar.com");
            int port4 = foo4.Port;  // it will return 443 - default for HTTPS
            Console.WriteLine(port1);
            Console.WriteLine(port2);
            Console.WriteLine(port3);
            Console.WriteLine(port4);
        }
    }
