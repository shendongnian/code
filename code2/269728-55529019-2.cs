    private void Msg_Click(object sender, RoutedEventArgs e)
        {
            //running at all
            if (Process.GetProcessesByName("OUTLOOK").Any())
            {
                try
                {
                    var app = (Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Outlook.Application");
                }
                //running normally
                catch (InvalidCastException)
                {
                  
                }
                //running as admin
                catch (System.Runtime.InteropServices.COMException)
                {
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
