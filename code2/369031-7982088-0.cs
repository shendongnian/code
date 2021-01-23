    int state = 0;
    private void IPAddressTxtBox_TextChanged(object sender, TextChangedEventArgs e)
    {
                if (state != 1)
                {
                    char[] allowedChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };
                    string inputText = this.IPAddressTxtBox.Text;
    
                    string result = "";
                    foreach (char c in inputText)
                    {
                        if (allowedChars.Contains(c))
                        {
                            result += c.ToString();
                        }
                    }
                    if (!this.IPAddressTxtBox.Text.Equals(result))
                    {
                        this.IPAddressTxtBox.Text = result;
                        this.state = 1;
                        this.IPAddressTxtBox.SelectionStart = this.IPAddressTxtBox.Text.Length;
                    }
                    
                }
                else if (state == 1)
                {
                    state = 2;
                }
            }
