     private void button1_Click(object sender, EventArgs e)
            {
                int a = Convert.ToInt32(richTextBox1.Text);
                CreateTextbox(a);
            }
    
            public void CreateTextbox(int line)
            {
                int count = 0;
                int num = 0;
                for (int i = 0; i < line*4; i++)
                {
                    TextBox box = new TextBox();
                    box.Name = "A" + i.ToString();
                    if (count >= 4)
                    {
    
                        count = 0;
                        num++;
                    }
                  
                    box.Location = new Point(count*(box.Width+20),num*40);
                    count++;
                    this.Controls.Add(box);
                }
                
                
            }
        }
