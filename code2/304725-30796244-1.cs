        public string GetProductCode(string productName)
        {
            string query = string.Format("select * from Win32_Product where Name='{0}'", productName);
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                foreach (ManagementObject product in searcher.Get())
                    return product["IdentifyingNumber"].ToString();
            }
            return null;
        }
