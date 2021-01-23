         private void button1_Click (object sender, EventArgs e)
         {
             Task task = new Task (new Action (Count));
             task.Start ();
         }
         void Count ()
         {
             for (int i = 0; i <99; i + +)
             {
                 Thread.Sleep (1);
                 if(progressBar1.InvokeRequired)
                 {
                      int j = i; //This is required to capture the variable, if you do not do this
                                 // the delegate may not have the correct value when you run it;
                      progressBar1.Invoke(new Action(() => progressBar1.Value = j));
                 }
                 else
                 {
                     progressBar1.Value = i;
                 }
             }
         }
