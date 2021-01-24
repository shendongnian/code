    private void copy(Attachment attachment, string folderName, string problemId)
    {
        ...
        try
        {
            using (fs = new FileStream(Path.Combine(exportPath, attachment.Name), FileMode.Create))
            {
                awaitfs.WriteAsync(attachment.Data, 0, attachment.Data.Length, this.cts.Token);
                fs.Flush();
                fs.Close();
                this.exportPopUp.performProgressBarStep();
            }           
        }
        ...
