    public class Program
    {
                     
        [System.Runtime.InteropServices.DllImport("advapi32.dll")]
        public static extern bool LogonUser(string userName, string domainName, string password, int LogonType, int LogonProvider,ref IntPtr phToken);
 
        static void Main(string[] args)
        {
            Program obj = new Program();
            bool isValid = obj.IsValidateCredentials("myUserName","MyPassword","MyDomain");
            Console.WriteLine(isValid == true ? "Valid User details" : "Invalid User Details");
            Console.Read();
            //// instead of console.readline and writeline, open your protected form.
        }
               
        public bool IsValidateCredentials(string userName, string password, string domain)
        {
            IntPtr tokenHandler = IntPtr.Zero;
            bool isValid = LogonUser(userName, domain, password, 2, 0, ref tokenHandler);
            return isValid;
        }
    }
