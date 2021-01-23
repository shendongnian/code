      private void button1_Click(object sender, System.EventArgs e)
        {
            String strItem;
            foreach(Object selecteditem in listBox1.SelectedItems)
            {
                strItem = selecteditem as String;
                System.Diagnostics.Debug.WriteLine(strItem);
                //Process(strItem);
            }
        }
