     // i am creating a new object here but , you can have a single object on the form
        DataGridView dgv = new DataGridView();
 
        private DataTable EmailSource { get; set; }
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.SelectionChanged+=new EventHandler(dgv_SelectionChanged);
            
     
            Chilkat.MessageSet msgSet = imap.Search("ALL", true);
            if (msgSet != null)
            {
                bundle = imap.FetchBundle(msgSet);
           
                CreateDataTable();
                if (bundle != null && dt!=null)
                {
                    Chilkat.Email email;
                    int i;
                    for (i = 0; i < bundle.MessageCount; i++)
                    {
                        email = bundle.GetEmail(i);
                        if(email!=null)
                        {
                        DataRow drow = EmailSource.NewRow();
                        drow["Id"] = i.ToString();
                        drow["From"] = email.FromName;
                        drow["Subject"] = email.Subject;
                        drow["DateRecived"] = email.DateRecived;
                        // i am adding email body also
                        drow["Body"] =email.Body;
                        EmailSource.Rows.Add(drow);
                        }
                    }
                    // Save the email to an XML file 
                    bundle.SaveXml("email.xml"); 
                    
          
                 
                   dgv.DataSource= EmailSource;
                    // Hiding Body from the grid
                   dgv.Columns["Body"].Visible =false;
           
                }
            }
        // this event handler will show the last selected email.
       void dgv_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dgv.SelectedRows;
            if (rows != null)
            {
                // get the last  selected row
                DataRow drow = rows[rows.Count - 1].DataBoundItem as DataRow;
                if (drow != null)
                {
                    richTextBox1.Text = drow["Body"];
                }
            }
        }
          
        private void CreateDataTable()
        {
            EmailSource = new DataTable();
            EmailSource.Columns.Add("Id");
            EmailSource.Columns.Add("From");
            EmailSource.Columns.Add("Subject");
            EmailSource.Columns.Add("DateRecived");
            EmailSource.Columns.Add("Body");
            
        }
