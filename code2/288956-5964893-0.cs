            string txt = System.IO.File.ReadAllText("file.txt");
            System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex(@"[A-Za-z0-9]+");
            foreach(System.Text.RegularExpressions.Match m in rx.Matches(txt))
            {
                If(m.Value.Trim().length>0)
                    MyComboBox.Items.Add(m.Value);
            }
