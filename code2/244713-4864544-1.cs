     UrlInfo u1 = new UrlInfo { Name = "test 1", Id = 1, Enabled = false };
     UrlInfo u2 = new UrlInfo { Name = "test 2", Id = 2, Enabled = true };
     UrlInfo u3 = new UrlInfo { Name = "test 3", Id = 3, Enabled = false };
     checkedListBox1.Items.Add(u1, u1.Enabled);
     checkedListBox1.Items.Add(u2, u2.Enabled);
     checkedListBox1.Items.Add(u3, u3.Enabled);
