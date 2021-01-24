    private void Upload_Click(object sender, EventArgs e)
    {
        List<Task> tskCopy = new List<Task>();
    
        for (int i = 0; i < 20; i++)
        {
            tskCopy.Add(Task.Run(() =>
            {
                while (FileData.Count > 0)
                {
                    string[] file;
                    FileData.TryTake(out file);
                    if (file != null && file.Count() > 3)
                    {
                       /* Upload Logic*/
                        GC.Collect();
                    }
                }
            }));
        }
    
        Task.WaitAll(tskCopy.ToArray());
        MessageBox.Show("Upload Complited Successfully");
    }
