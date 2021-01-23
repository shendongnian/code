    for (int i = 1; i < 11; i++)
        {
            name[i] = new TextBox(); // insert this line
            if (i == 10)
            {
                strPath = str + "0" + i + ".jpg";
            }
            else
            {
                strPath = str + "00" + i + ".jpg";
            }
            name[i].Text = strPath;
            listBox1.Items.Add(name[i]);
        }
