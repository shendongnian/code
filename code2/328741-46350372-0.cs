        static void Main(string[] args)
        {
            using (new Impersonator("username", "domainName", "myPassword"))
            {
                // The following code is executed under the impersonated user.
                AddPrinterUnc(@"\\PrintServer\printershare");
            }
        }
        public static void AddPrinterUnc(string printUncPath)
        {
                using (ManagementClass oPrinterClass = new ManagementClass(new ManagementPath("Win32_printer"), null))
                {
                    using (ManagementBaseObject oInputParameters = oPrinterClass.GetMethodParameters("AddPrinterConnection"))
                    {
                        oInputParameters.SetPropertyValue("Name", printUncPath);
                        oPrinterClass.InvokeMethod("AddPrinterConnection", oInputParameters, null);
                    }
                }
            
        }
