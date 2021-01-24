    int ProcessIDDaca = 111111111;
            private void btnDacaStart_Click(object sender, EventArgs e)
            {
    
                try
                {
                    using (Process myprocess = new Process())
                    {
                        myprocess.StartInfo.UseShellExecute = false;
                        myprocess.StartInfo.FileName = @"C:\Users\nx011116\Documents\MachineMonitor\CopyChimp_Server\bin\Debug\CopyChimpServer.exe";
                        //myprocess.StartInfo.FileName = @"C:\Program Files\Eltima Software\Virtual Serial Port Driver 9.0\vspdconfig.exe";
                        myprocess.StartInfo.CreateNoWindow = true;
    
                        if (btnDacaStart.Text == "Stop")
                        {
                            Process proc = Process.GetProcessById(ProcessIDDaca);
                            proc.Kill();
                            btnDacaStart.Text = "Start";
                            lblDacaID.Text = "";
                        }
                        else
                        {
                            myprocess.StartInfo.Arguments = "test";
                            myprocess.Start();
                            var s = myprocess.Id;
                            ProcessIDDaca = myprocess.Id;
                            lblDacaID.Text = s.ToString();
                            btnDacaStart.Text = "Stop";
                        }
    
                    }
                }
    
                catch (Exception ex)
                {
    
                }
    
            }
    public static string copychimp_server = "";
      public static int port_number = 0;
    
      static void Main(string[] args)
            {
                Console.Write("Enter copychimp server: ");
                //Here i need to provide
                copychimp_server = args[0];
                Console.Write("Enter port number: ");
                //Here i need to provide
                port_number = Convert.ToInt16(Console.ReadLine());
    
    
            }
