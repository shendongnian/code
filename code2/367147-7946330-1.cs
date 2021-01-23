       private void PrintButton_Click(object sender, EventArgs e)
        {
            stringToPrint = tabsProperties[tabsProperties.IndexOf(new TabProperties(this.tabControl1.SelectedIndex))].TabHtml;
            printDialog1.ShowDialog();
            printDocument1.Print();
                       
        }
