            private StringBuilder GetSystemInformationString()
            {
                StringBuilder sb = new StringBuilder();
                PropertyInfo[] properties = typeof(System.Windows.Forms.SystemInformation).GetProperties();
                if (properties != null && properties.Length > 0)
                {
                    foreach (PropertyInfo pin in properties)
                    {
                        sb.Append(System.Environment.NewLine);
                        sb.Append(pin.Name + " : " + pin.GetValue(pin, null));
                    }
                }
    
                return sb;
    
            }
