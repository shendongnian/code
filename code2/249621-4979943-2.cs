    partial class Form1 : Form
    {
       Timer timer = new Timer();
    
       private void button1_Click(object sender, EventArgs e)
       {
          int i = 0;
    
          timer.Tick += (s, e) =>
          {
             if (i < 8)
             {
                   label1.Text = nameList[r.Next(5)];
                   i++;
             }
             else
                timer.Stop();
          };
    
          timer.Interval = 1000;
          timer.Start();
       }
    }
