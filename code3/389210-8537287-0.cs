    public static void ShowMessage(this Label label, string text)
            {
                if (label.InvokeRequired)
                {
                    lablel.Invoke((UpdateState)delegate
                    {
                        label.Text = text;
                    });
                }
                else
                {
                      label.Text = text;
                }
            }
