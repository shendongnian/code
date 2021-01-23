    if (Page.IsValid)
            {
                DateTime exhibitDate = DateTime.Now;
                int caseid = Convert.ToInt32(CaseIDDropDownList.SelectedItem.Text);
                string exhibittype = exhibitTypeTextBox.Text.ToString();
                string storedloc = storedLocationTextBox.Text.ToString();
                string offid = DropDownList1.SelectedItem.Text.ToString();
                Stream imgStream = exhibitImageFileUpload.PostedFile.InputStream;
                int imgLen = exhibitImageFileUpload.PostedFile.ContentLength;                
                byte[] imgBinaryData = new byte[imgLen];
                int n = imgStream.Read(imgBinaryData,0,imgLen);
                try
                {
                    SqlConnection connections = new SqlConnection(strConn);
                    SqlCommand command = new SqlCommand("INSERT INTO Exhibits (CaseID, ExhibitType, ExhibitImage, DateReceived, StoredLocation, InvestigationStatus, OfficerID, SuspectID, InvestigatorID, ManagerID, AdminID ) VALUES (@CaseID, @ExhibitType, @ExhibitImage, @DateReceived, @StoredLocation, @InvestigationStatus, @OfficerID, @SuspectID, @InvestigatorID, @ManagerID, @AdminID)", connections);
    				command.Parameters.AddWithValue("@CaseID", caseid);
    				//and so on for your 10 parameters
           
    
               
    
                    connections.Open();
                    int numRowsAffected = command.ExecuteNonQuery();
                    connections.Close();
    
                    if (numRowsAffected != 0)
                    {
                        Response.Write("<BR>Rows Inserted successfully");
                        CaseIDDropDownList.ClearSelection();
                        exhibitTypeTextBox.Text = null;
                        storedLocationTextBox.Text = null;
                        DropDownList1.ClearSelection();
                    }
                    else
                    {
                        Response.Write("<BR>An error occurred uploading the image");
                    }
                }
                catch (Exception ex)
                {
                    string script = "<script>alert('" + ex.Message + "');</script>";
 
                   }
    }
