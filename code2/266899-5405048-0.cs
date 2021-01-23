    StreamReader sr;
    public void button1_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            label1.Text = openFileDialog1.FileName;
            sr = new StreamReader(label1.Text);
            String strNumVertices = sr.ReadLine();
            label2.Text = strNumVertices;
        }
    }
    public void Form1_Paint(object sender, PaintEventArgs e)
        perspectiveMatrix = new Gmatrix("perspective");
        translationMatrix = new Gmatrix("translation");
        scalingMatrix = new Gmatrix("scaling");
        perspectiveMatrix.initAsPerspectiveMatrix(300);
        scalingMatrix.initAsScalingMatrix(10, 10, 10);
        translationMatrix.initAsTranslationMatrix(150, 50, 1200);
        
        if (sr != null) {
           String strNumVertices = sr.ReadLine();
           label1.Text = strNumVertices;
        }
