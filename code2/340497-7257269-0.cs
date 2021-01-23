    private void button1_Click(object sender, EventArgs e)
    {
    WebClient myWebClient = new WebClient();
    string fileName = textBox1.Text;
    string _path = Application.StartupPath;
    MessageBox.Show(_path);
    _path = _path.Replace("Debug", "Images");
    MessageBox.Show(_path);
    myWebClient.UploadFile(_path,fileName);
    }
    
    private void btnBrowse_Click(object sender, EventArgs e)
    {
    OpenFileDialog ofDlg = new OpenFileDialog();
    ofDlg.Filter = "JPG|*.jpg|GIF|*.gif|PNG|*.png|BMP|*.bmp";
    if (DialogResult.OK == ofDlg.ShowDialog())
    {
    textBox1.Text = ofDlg.FileName;
    button1.Enabled = true;
    }
    else
    {
    MessageBox.Show("Go ahead, select a file!");
    }
    
    }
