private void textEditKeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 220)
            {
                e.SuppressKeyPress = true;                
                MessageBox.Show( @"\ not allowed. Use / instead.");
               
            }
        }
By changing the code to 
private async void tEditDropBoxFolderName_EditValueChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 220)
            {
                e.SuppressKeyPress = true;
                await Task.Delay(100);
                MessageBox.Show( @"\ not allowed. Use / instead.");
               
            }
        }
Everything works fine, and i havent found any side effects by using this.
