      int cnt = 0;
        while (TextBox1.Text.Contains(" "))
        {
            cnt++;
            if (cnt > 1)
            {
                MessageBox.show("Only a space is allowed");
                break;
            }
        }
