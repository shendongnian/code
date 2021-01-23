        private void Test_DragDrop(object sender, DragEventArgs e)
        {
            string[] formats = e.Data.GetFormats();
            foreach (string s in formats)
            {
                try
                {
                    string d = (string)e.Data.GetData(s);
                    MessageBox.Show(s + "\n" + d);
                }
                catch { }
            }
        }
