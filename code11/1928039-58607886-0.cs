      private async void button3_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 1;
            var progress = new Progress<int>(percent =>
              {
                  progressBar1.Value = percent;
              });
             await Convert();
        }
     private void Form1_Load(object sender, EventArgs e)
        { progressBar1.Minimum = 1;
            progressBar1.Maximum = 100;
        }
