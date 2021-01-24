        public event IndexChangeHandler IndexChanged;
        public delegate void IndexChangeHandler (object s);
         private void button4_Click(object sender, EventArgs e)
        {
            
            Task.Run(() =>
            {
                int temp = 0; 
                while (true)
                {
                    System.Threading.Thread.Sleep(2000);
                   
                    comboBox1.BeginInvoke((MethodInvoker)delegate
                   {
                       if (comboBox1.Items.Count != temp)
                       {
                           IndexChanged(this);
                           temp= comboBox1.Items.Count;
                       }
                   });
                }
            });
            IndexChanged += Form1_IndexChanged;
            for (int i = 0; i < 5; i++)
            {
                comboBox1.Items.Add(i);
            }
            
        }
         private void Form1_IndexChanged(object s)
        {
            MessageBox.Show("Test");
        }
