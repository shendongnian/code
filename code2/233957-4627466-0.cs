     using System.Diagnostics;
     public partial class Form1 : Form {
     
         Stopwatch s;
     ...
     
         private void btnStart_Click(object sender, EventArgs e)
         {
             if (s == null)
                  s = new Stopwatch();
           
             s.Restart();
         }
    
         private void btnEnd_Click(object sender, EventArgs e)
         {
              if (s == null)
                  return;
          
               s.Stop();
          
              lblElapsed.Text = s.Elapsed;
         }
     ...      
     } 
     
