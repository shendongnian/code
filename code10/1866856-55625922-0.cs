    public partial class frmSettings : Form
    {
    
            protected string FileName;
            protected bool Modified;
            Setting _objSetting = new Setting();
            OpenFileDialog openFD = new OpenFileDialog();
            DataTable _dt = new DataTable();
    		
    		public frmSettings()
    		{            
    			InitializeComponent();
    		}
    		
    		private void mnuOpen_Click(object sender, EventArgs e)
            {
                Cursor = Cursors.WaitCursor;
                try
                { 
                    openFD.Title = "Open a CSV File";
                    if (SaveIfModified())
                    {
                        if (openFD.ShowDialog(this) == DialogResult.OK)
                        {
                            _dt = _objSetting.ProcessSettingFileCMD(openFD.FileName);
                            if (_dt.Rows.Count > 0)
                            {
                                gvSettings.DataSource = _dt;
                            }
                        }
                    }
                    FileName = openFD.FileName;
                    Modified = false;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(String.Format("Error reading from {0}.\r\n\r\n{1}", FileName, ex.Message));
                }
                finally
                {
                    Cursor = Cursors.Default;
                }            
            }
        }
	
