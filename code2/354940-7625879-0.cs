    public enum FormType
            {
                MDI,
                Child
            }
            
            public static void PaintFrom(Form frm, PaintEventArgs e, FormType formType)
            {
                if (formType == FormType.MDI)
                {
                    Graphics mGraphics = e.Graphics;
                    Pen pen1 = new Pen(Color.FromArgb(96, 155, 173), 1);
    
                    Rectangle Area1 = new Rectangle(0, 0, frm.Width - 1, frm.Height - 1);
                    LinearGradientBrush LGB = new LinearGradientBrush(Area1, Color.FromArgb(96, 155, 173), Color.FromArgb(245, 251, 251), LinearGradientMode.Vertical);
                    mGraphics.FillRectangle(LGB, Area1);
                    mGraphics.DrawRectangle(pen1, Area1);
                    PictureBox picBox = new PictureBox();
                    Color backColor = Color.Transparent;
                    Bitmap bm = new Bitmap(ImagePath + "title_bar.png");
                    //frm.Controls.Add(picBox);
                    Point pt = new Point(0, 0);
                    picBox.Location = pt;
                    picBox.Image = bm;
                    picBox.Width = frm.Width - 1;
                    picBox.Height = 24;//frm.Height - 1;
                    picBox.BackColor = backColor;
                    picBox.BackgroundImageLayout = ImageLayout.Stretch;
    
    
                    PictureBox closeBox = new PictureBox();
                    //frm.Controls.Add(closeBox);
                    bm = new Bitmap(ImagePath + "close.gif");
                    pt = new Point(frm.Width - (bm.Width), -1);
                    closeBox.Location = pt;
                    closeBox.Image = bm;
                    closeBox.Width = bm.Width + 1;
                    closeBox.Height = bm.Width + 1;
                    closeBox.BackColor = backColor;
                    closeBox.BackgroundImageLayout = ImageLayout.Stretch;
    
                    PictureBox minBox = new PictureBox();
                    //frm.Controls.Add(closeBox);
                    bm = new Bitmap(ImagePath + "close.gif");
                    pt = new Point(frm.Width - (2*(bm.Width))-1, bm.Width);
                    minBox.Location = pt;
                    minBox.Image = bm;
                    minBox.Width = bm.Width + 1;
                    minBox.Height = bm.Width + 1;
                    minBox.BackColor = backColor;
                    minBox.BackgroundImageLayout = ImageLayout.Stretch;
    
                    frm.Controls.Add(picBox);
                    picBox.Controls.Add(closeBox);
                    picBox.Controls.Add(minBox);
                    minBox.Click+=new EventHandler(minBox_Click);
                    closeBox.Click += new EventHandler(closeBox_Click);
                }
                else
                {
                    PaintForm(frm, e);
                }
            }
            public static void PaintForm(Form frm, PaintEventArgs e)
            {
                
                Graphics mGraphics = e.Graphics;
                Pen pen1 = new Pen(Color.FromArgb(96, 155, 173), 1);
    
                Rectangle Area1 = new Rectangle(0, 0, frm.Width - 1, frm.Height - 1);
                LinearGradientBrush LGB = new LinearGradientBrush(Area1, Color.FromArgb(96, 155, 173), Color.FromArgb(245, 251, 251), LinearGradientMode.Vertical);
                mGraphics.FillRectangle(LGB, Area1);
                mGraphics.DrawRectangle(pen1, Area1);
                PictureBox picBox=new PictureBox();
                Color backColor = Color.Transparent;
                Bitmap bm=new Bitmap(ImagePath+"title_bar.png");
                //frm.Controls.Add(picBox);
                Point pt=new Point(0,0);
                picBox.Location = pt;
                picBox.Image = bm;
                picBox.Width = frm.Width - 1;
                picBox.Height = 24;//frm.Height - 1;
                picBox.BackColor = backColor;
                picBox.BackgroundImageLayout = ImageLayout.Stretch;
    
               
                PictureBox closeBox = new PictureBox();
                //frm.Controls.Add(closeBox);
                bm = new Bitmap(ImagePath + "close.gif");
                pt = new Point(frm.Width - (bm.Width), -1);
                closeBox.Location = pt;
                closeBox.Image = bm;
                closeBox.Width = bm.Width + 1;
                closeBox.Height = bm.Width + 1;
                closeBox.BackColor = backColor;
                closeBox.BackgroundImageLayout = ImageLayout.Stretch;
                
                foreach (Control ctr in frm.Controls)
                {
                    if (ctr.HasChildren)
                    {
                        if (ctr is DataGridView)
                        {
                            DataGridView dtg = ctr as DataGridView;
                            DataGridViewCellStyle dtstyle=new DataGridViewCellStyle();
                            dtstyle.BackColor = Color.FromArgb(96, 155, 173);
                            dtg.ColumnHeadersDefaultCellStyle = dtstyle;
                        }
                        else if (ctr is TextBox)
                        {
                        }
                        else if (ctr is TabControl)
                        {
                            
                        }
                        else
                        {
                            ctr.BackColor = backColor;
                        }
                       
                    }
                    if (ctr is Label)
                    {
                        ctr.BackColor = backColor;
                    }
                   
                }
    
    
                frm.Controls.Add(picBox);
                picBox.Controls.Add(closeBox);
                closeBox.Click+=new EventHandler(closeBox_Click);
                
            }
            static void closeBox_Click(object sender, EventArgs e)
            {
                PictureBox close = sender as PictureBox;
                PictureBox pic = close.Parent as PictureBox;
                Form fm = pic.Parent as Form;
                fm.Close();
            }
            static void minBox_Click(object sender, EventArgs e)
            {
                PictureBox min = sender as PictureBox;
                PictureBox pic = min.Parent as PictureBox;
                Form fm = pic.Parent as Form;
                fm.WindowState = FormWindowState.Minimized;
            }
