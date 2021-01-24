     private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    var txt = new TextBox()
                    {
                        Name = $"textBox{i}{j}",
                        Width = 50,
                        Height = 20,
                        Location = new Point(50 * j, 20 * i)
                    };
                    this.Controls.Add(txt); //Add new TextBox to your form's controls
                }
            }
        }
