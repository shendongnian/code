    using Microsoft.Win32;
    ...
 
            var devices = Registry.CurrentUser.OpenSubKey( @"Software\Microsoft\Windows NT\CurrentVersion\Devices" ); //Read-accessible even when using a locked-down account
            string printerName = "Adobe PDF";
            try
            {
                foreach ( string name in devices.GetValueNames() )
                {
                    if ( Regex.IsMatch( name, printerName, RegexOptions.IgnoreCase ) )
                    {
                        var value = (String)devices.GetValue( name );
                        var port = Regex.Match( value, @"(Ne\d+:)", RegexOptions.IgnoreCase ).Value;  
                        return printerName + " on " + port;
                    }
                }
            }
            catch
            {
                throw;
            }
