    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    
    class Program
    {
        [DllImport("msi.dll", SetLastError = true)]
        static extern int MsiEnumProducts(int iProductIndex, StringBuilder lpProductBuf);
    
        [DllImport("msi.dll", CharSet = CharSet.Unicode)]
        static extern Int32 MsiGetProductInfo(string product, string property, [Out] StringBuilder valueBuf, ref Int32 len);
    
        public const int ERROR_SUCCESS = 0;
        public const int ERROR_MORE_DATA = 234;
        public const int ERROR_NO_MORE_ITEMS = 259;
    
        static void Main(string[] args)
        {
            int index = 0;
            StringBuilder sb = new StringBuilder(39);
            while (MsiEnumProducts(index++, sb) == 0)
            {
                var productCode = sb.ToString();
                var product = new Product(productCode);
                Console.WriteLine(product);
            }
        }
        
        class Product
        {
            public string ProductCode { get; set; }
            public string ProductName { get; set; }
            public string ProductVersion { get; set; }
    
            public Product(string productCode)
            {
                this.ProductCode = productCode;
                this.ProductName = GetProperty(productCode, "InstalledProductName");
                this.ProductVersion = GetProperty(productCode, "VersionString");
            }
    
            public override string ToString()
            {
                return this.ProductCode + " - Name: " + this.ProductName + ", Version: " + this.ProductVersion;
            }
    
            static string GetProperty(string productCode, string name)
            {
                int size = 0;
                int ret = MsiGetProductInfo(productCode, name, null, ref size); if (ret == ERROR_SUCCESS || ret == ERROR_MORE_DATA)
                {
                    StringBuilder buffer = new StringBuilder(++size);
                    ret = MsiGetProductInfo(productCode, name, buffer, ref size);
                    if (ret == ERROR_SUCCESS)
                        return buffer.ToString();
                }
    
                throw new System.ComponentModel.Win32Exception(ret);
            }
        }
    }
