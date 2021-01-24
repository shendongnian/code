      public frmYazdir(TblBilgi tbl)
        {
            InitializeComponent();
            db = new DbEntities1();
            if (tbl != null)
            {
                tblBilgiBindingSource.DataSource = tbl;
            }
        } 
    private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog DosyaYukle = new OpenFileDialog();
            DosyaYukle.Filter = "REPX Dosyaları(*repx.*) | *.repx*";
            if (DosyaYukle.ShowDialog() == DialogResult.OK)
            {
                filename = DosyaYukle.FileName;
                textBox1.Text = filename;
                if (tbl != null)
                {
                    db.TblBilgi.Attach(tblBilgiBindingSource.DataSource as TblBilgi);
                }
            }
        }
    private void button2_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
            MessageBox.Show("Kaydedildi.");
        }
