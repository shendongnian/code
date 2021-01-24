       private async void btnListFiles1_Click(object sender, EventArgs e)
      {
         
         if (txtDirectory1.Text == "")
         {
           MessageBox.Show(InfoDialog.SELECT_DIRECTORY,PROGRAM_NAME);
            return;
         }
         if (!Directory.Exists(txtDirectory1.Text))
         {
           MessageBox.Show(InfoDialog.DIRECTORY_NOT_EXIST, PROGRAM_NAME);
            return;
         }
         try
         {
            string fileTypes = (txtFileTypes1.Text == "") ? "" : txtFileTypes1.Text;
            string[] files = Directory.GetFiles(txtDirectory1.Text.TrimEnd(),
                     (fileTypes == "") ? "*.*" : fileTypes,
                     (chkSub1.Checked) ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            listBoxFiles.Items.Clear();         
            progressBar.Step = 1;
            progressBar.Value = 1;
            progressBar.Maximum = files.Length + 1;
            listBoxFiles.BeginUpdate();
            if (txtSearchPattern1.Text != "")
            {
               string searchPattern = txtSearchPattern1.Text.ToLower();
               await System.Threading.Tasks.Task.Run(() =>
               {
                  foreach (string file in files)
                  {
                     if (file.ToLower().Contains(searchPattern))
                     {
                        AddToListBox(file);
                     }
                  }
               });
            }
            else
            {
               await System.Threading.Tasks.Task.Run(() =>
               { 
                  foreach(string file in files)
                  {
                     AddToListBox(file);
                  }
               });
            }
            listBoxFiles.EndUpdate();
            progressBar.Value = 0;
         
      }
    private void AddToListBox(string item)
      {
         synchronizationContext.Send(new SendOrPostCallback(o =>
         {
            listBoxFiles.Items.Add((string)o);
            progressBar.Value++;
         }), item);         
      }
