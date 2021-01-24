    private void ExtractArchive(object sender, EventArgs e)
    {
        try
        {
            using (ZipFile zip = ZipFile.Read(txtArchiveName.zip))
            {
                // Loop through the archive's files.
                foreach (ZipEntry zip_entry in zip)
                {
                    zip_entry.Extract(txtExtractTo);
                }
            }
    
            MessageBox.Show("Done");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error extracting archive.\n" +
                ex.Message);
        }
    }
