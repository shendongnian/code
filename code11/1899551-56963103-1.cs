    protected void btnEkspor_Click(object sender, EventArgs e)
            {
                if (cbEkspor.SelectedItem.Value.ToString().Equals("xls"))
                    gvExport.WriteXlsToResponse();
                else if (cbEkspor.SelectedItem.Value.ToString().Equals("xlsx"))
                    gvExport.WriteXlsxToResponse();
                else if (cbEkspor.SelectedItem.Value.ToString().Equals("pdf"))
                    gvExport.WritePdfToResponse();
                else if (cbEkspor.SelectedItem.Value.ToString().Equals("rtf"))
                    gvExport.WriteRtfToResponse();
            }
