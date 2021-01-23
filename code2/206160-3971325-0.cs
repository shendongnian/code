        Button btn = (Button)sender;
        if (radioButton1.Checked == true)
        {
            i = int.Parse(btn.Name);
            j = i % 8;
            for (y = 1; y <= 8; j+=8)
            {
               if(!btn.equals(this.Controls[y]))
                  this.Controls[y].BackColor = Color.Red;
            }
        }
