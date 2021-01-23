    private byte[] inkData;
    
    private void btnSave_Click(object sender, EventArgs e)
    {
        inkData = ink.Ink.Save(PersistenceFormat.Gif, CompressionMode.Maximum);
    }
    
    private void btnExport_Click(object sender, EventArgs e)
    {
        // Data is already in GIF format, write directly to file!
    }
