    private void Form1_Load(object sender, EventArgs e)
    {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        _arr[i, j] = new Label();
                        _arr[i, j].Text = "" + i + "," + j;
                        _arr[i, j].Size = new Size(50, 50);
                        _arr[i, j].Location = new Point(j * 50, i * 50);         //you can set other property here like Border or else         
                        _arr[i, j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        this.Controls.Add(_arr[i, j]);
    
                        _arr[i, j].MouseMove += new MouseEventHandler(Form1_MouseMove);
                    }
                }
    }
    void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        label1.Text = ((Label)sender).Text;
    }
