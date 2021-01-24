      private void button1_Click(object sender, EventArgs e)
        {
            string DemoPath = @"D:\MyImages\MyPicture.jpg";
            
            string filestring = Path.GetFileName(DemoPath); //filename only
            string pathstring = Path.GetDirectoryName(DemoPath); //path only
            MyFileInfo nfo = new MyFileInfo(); //instantiate your object
            nfo.fileName = filestring; //fill the properties
            nfo.filePath = pathstring;
            listBox1.Items.Add(nfo); //add it to the listbox (only filename shows)
         }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //cast the selected item back to the MyFileInfoType and get its filePath
            string pathFromSelection = (listBox1.SelectedItem as MyFileInfo).filePath;
            MessageBox.Show(pathFromSelection);
        }
    class MyFileInfo
    {
        public string fileName { get; set; }
        public string filePath { get; set; }
        public override string ToString()
        {
            //Here we tell the object to only display the filename
            return fileName;
        }
    }
