    static void Main(string[] args)
    {
            try
            {
                GetAppSettingsFile();
    
                var service = new ProPayService(_iconfiguration);
                
                service.MerchantSignUpForProPay();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
    
    
            Console.WriteLine("\r\nPress any key to continue");
            Console.Read();
    }
