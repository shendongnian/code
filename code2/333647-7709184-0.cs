        internal static bool IsV40Installed()
        {
            try
            {
                System.Reflection.Assembly.Load("System.Data.SqlServerCe, Version=4.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91");
            }
            catch (System.IO.FileNotFoundException)
            {
                return false;
            }
            try
            {
                var factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlServerCe.4.0");
            }
            catch (System.ArgumentException)
            {
                return false;
            }
            return true;
        }
        internal static bool IsV35Installed()
        {
            try
            {
                System.Reflection.Assembly.Load("System.Data.SqlServerCe, Version=3.5.1.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91");
            }
            catch (System.IO.FileNotFoundException)
            {
                return false;
            }
            try
            {
                var factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlServerCe.3.5");
            }
            catch (System.ArgumentException)
            {
                return false;
            }
            return true;
        }
