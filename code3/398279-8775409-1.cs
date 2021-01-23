     bool succeeded = MCU_Connect_Received.WaitOne(timeOutInMilliseconds, false);
     if (succeeded)  
     {
           textBox1.AppendText("Success!" + Environment.NewLine);         
     }
     else
     {
           textBox1.AppendText("Failed!" + Environment.NewLine);         
     }
