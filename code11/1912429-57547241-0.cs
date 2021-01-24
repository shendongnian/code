csharp
pb.Click += new EventHandler((s, e1) => this.PictureBox1_Click(s, e1, tempValue))
You can also make use of closures and rather than extracting your click handling code into a separate function it could all be done inline.
For example:
csharp
private void Form1_Load(object sender, EventArgs e)
    {
        daoConn dc = new daoConn();
        List<Model> models = new List<Model>();
        string url;
        string fName;
        models = dc.GetAllModels();
        foreach (Model m in models)
        {
            int tempValue;
            tempValue = 1;
            PictureBox pb = new PictureBox();
            url = baseUrl + m.MhsUrl;
            fName = m.mFirstName;
            Size size = new Size(100, 100);
            pb.ImageLocation = url;
            pb.Size = size;
            pb.Click += (s,clickEvent) => {
                // You can use of pb directly here
                // You also have access to things like models too.
                string j = pb.ImageLocation;
                MfNameTxt.Text = "Chris";
                MessageBox.Show("Clicked! " + j);
            };
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            modelHsFlowLayout.Controls.Add(pb);
        }
    }
