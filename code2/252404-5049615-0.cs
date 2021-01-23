    foreach (var c in this.Controls)
            {
                if (c is Button)
                    ((Button)c).Click += new System.EventHandler(this.Buttons_Click);
            }
