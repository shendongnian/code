    private void button1_Click(object sender, EventArgs e)
            {           
                        SHDocVw.InternetExplorerMedium IE = new SHDocVw.InternetExplorerMedium();
                        IE.Visible = true;
                        IE.Navigate("www.microsoft.com");    
            }
