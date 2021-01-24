    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            rtbComment.MinimumSize = new Size(250, 200);
            rtbComment.MaximumSize = new Size(250, 400);
            rtbComment.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            rtbComment.ContentsResized += rtbComment_ContentResized;
    
        }
    
        private void rtbComment_ContentResized(object sender, ContentsResizedEventArgs e)
        {
            rtbComment.Size = e.NewRectangle.Size;
        }
    }
