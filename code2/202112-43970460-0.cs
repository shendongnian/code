            control.TextChanged += (s, a) => {
                string value = string.Empty;
                foreach (char ch in control.Text.ToCharArray())
                {
                    if (char.IsDigit(ch))
                    {
                        value += ch.ToString();
                    }
                }
                control.Text = value;
            };
