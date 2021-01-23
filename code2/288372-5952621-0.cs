      public partial class Form1 : Form
      {
        List<Button> buttonList = new List<Button>();
        public Form1()
        {
          for (int n = 0; n < 100; n++)
          {
            Button tempButt = new Button();
            tempButt.Top = n*5;
            tempButt.Left = n * 5;
            this.Controls.Add(tempButt);
            buttonList.Add(tempButt);
          }
          var stopwatch = new Stopwatch();
          stopwatch.Start();
          foreach (Button butt in buttonList)
          {
            butt.Click += new System.EventHandler(button1_Click);
          }
          stopwatch.Stop();
          Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
          Console.WriteLine("Cheese");
        }
      }
