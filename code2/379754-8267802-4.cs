     // Form1
     public static void getSalesFigures()    
     {
       (...)
      //Now to access GUI elements from a worker thread, we need an method we can invoke. 
      //pictureBox2.Visible = true
      //checkBox1.Checked = true; 
     //=> call SetPictureBoxVisibility(true) or SetPictureBoxVisibility(false) in your Function to update the control on your GUI.
      SetPictureBoxVisibility(true);
     }
     // Runs non-threaded in the main thread - no control updates so its OK
     private void Form1_Load(object sender, EventArgs e)     
    {         
      AutofillAccounts();   
    } 
     // Form1
     private void button1_Click(object sender, EventArgs e)     
    {    
       // Check first, so we save one Invoke.
       checkBox1.Checked = true; 
      // We create a new Task     
      Task t = new Task( () => GetsalesFigures());  
      // Start the task which processes the GetSalesFigures()
      t.Start();
      // Task completed
      t.ContinueWith(task => Console.Writeline("Done"));
     } 
     // Form1
     private void SetPictureBoxVisibility(bool IsVisible)
     {
       if(pictureBox2.InvokeRequired)
       {
          pictureBox2.Invoke(new Action<bool>(SetPictureBoxVisibility,new Object[] { IsVisible })
       }
       else
       { 
          pictureBox2.Visible = isVisible;
       }
     }
