            string Command = "TheNameOfTheCurrentApp";                 
            string arguments = textBox1.Text;
            System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo(Command, arguments);
            start.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
            start.CreateNoWindow = true;
            start.UseShellExecute = true;
            System.Diagnostics.Process process = System.Diagnostics.Process.Start(start);        
