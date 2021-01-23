     string[] split = textBox1.Text.Split(',');
                 int count =0;
                 for (int i = 0; i < split.Length; i++)
                 {
                     count+=1;
                     if (i < split.Length - 1)
                     {
                         textBox2.Text += split.GetValue(i) + ",";
                     }
                     else
                     {
                         textBox2.Text += split.GetValue(i);
                     }
                     if (count == 3)
                     {
                         count = 0;
                         textBox2.Text += " </br> ";
                     }
                 }
