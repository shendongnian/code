     private void Form1_Load(object sender, EventArgs e)
     {
         int i = 1;
         var allLines = File.ReadAllLines(@"c:\temp\test.txt");
          
         foreach (var line in allLines)
         {
             var b = new Button();
             b.Text = line;
             b.AutoSize = true; 
             b.Location = new Point(0, b.Size.Height * i);
             this.Controls.Add(b);
             i++;
         }
     }
