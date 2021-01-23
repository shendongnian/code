       bool IsPrimaryInteropAssembliesInstalled()
        {
            try
            {
                if (Assembly.Load("Policy.11.0.Microsoft.Office.Interop.Word, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c") != null)
                {
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }
