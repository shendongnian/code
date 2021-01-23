       private void Msg_Click(object sender, RoutedEventArgs e)
        {
            var to = "mail@example.com";
            var subject = $"Message 'test'";
            var send = true;
            if (Process.GetProcessesByName("OUTLOOK").Any())
            {
                try
                {
                    var ol = (Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Outlook.Application");
                }
                //running as admin
                catch (System.Runtime.InteropServices.COMException)
                {
                    send = false;
                    MessageBox.Show($"Couldn't open Outlook. Create a new mail to {to} about {subject}");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            if (send)
            {
                Process.Start(new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = $"mailto:{to}?subject={subject}"
                });
            }
        }
