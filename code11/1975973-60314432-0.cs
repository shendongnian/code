     public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            ScrollBar hScrollBar1 = new HScrollBar();
            private void Form1_Load(object sender, EventArgs e)
            {
                panel1.BorderStyle = BorderStyle.FixedSingle;
                panel1.Dock = DockStyle.Left;
                panel2.BorderStyle = BorderStyle.FixedSingle;
                panel2.Dock = DockStyle.Fill;
                hScrollBar1.Dock = DockStyle.Bottom;
                hScrollBar1.Scroll += new ScrollEventHandler(hScroller_Scroll);
                panel2.Controls.Add(hScrollBar1);
                panel2.HorizontalScroll.Visible = false;
                panel2.HorizontalScroll.Enabled = true;
            }
            private void hScroller_Scroll(object sender, ScrollEventArgs e)
            {
                panel2.HorizontalScroll.Value = e.NewValue;
            }
        }
