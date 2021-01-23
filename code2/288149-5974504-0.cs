    private void btnSearchNow_Click(object sender, EventArgs e)
    {
        BLSecurityFinder lSecFinder = new BLSecurityFinderClass();
        int iCounter = 0;
        lbselected.Items.Clear();
        lSecFinder.bScanSubDirectories = chkSubfolders.Checked;
        using (StreamWriter writer = new StreamWriter(@"C:\results.txt", false))
        {
            try
            {
                lSecFinder.FindSecurity(txtSymbol.Text, txtDirectory.Text);
                while (lSecFinder.bSecLeft)
                {
                    // Insert(iCounter, lSecFinder.SecName);
                    lbselected.Items.Add(new SampleData() { Name = lSecFinder.SecName });
                    lbselected.DisplayMember = "Name";
                    // assuming SecName is the full filename
                    writer.WriteLine(lSecFinder.SecName); 
                    lSecFinder.FindNextSecurity();
    
                    iCounter++;
                }
            }
            catch (System.Runtime.InteropServices.COMException ComEx)
            {
                //MessageBox.Show (ComEx.Message);
            }
            finally
            {
                lSecFinder.DestroySearchDialog();
            }
        }
    }
