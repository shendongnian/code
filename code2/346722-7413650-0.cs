    public void btnZoek_Click(object sender, EventArgs e)
    {
        if (search == false)
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath + "\\Saves");
            System.IO.FileInfo[] rgFiles = di.GetFiles("*.txt");//add only .txt files
            foreach (System.IO.FileInfo fi in rgFiles)
            {
                OpenFiles[index] = new AddFileClass();
                OpenFiles[index].setNewItem(index, fi.Name, Convert.ToString(di));//send the info to the array (Number, filename, filelocation)
                index++;
            }
            search = true; //make sure it doens'nt add something double
        }
        if (search == true)
        {
            Form3_Zoeken_ frmSearch = new Form3_Zoeken_();
            frmSearch.Show();
        }
    }
