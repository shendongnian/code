    public partial class FTD_PG : Form
    {
        public FTD_PG()
        {
            InitializeComponent();
        }
        private Dictionary<PictureBox, CheckBox> differences = new Dictionary<PictureBox, CheckBox>();
        private void FTD_PG_Load(object sender, EventArgs e)
        {
            for(int i = 1; i <=5; i++)
            {
                PictureBox pb = this.Controls.Find("check_" + i.ToString(), true).FirstOrDefault() as PictureBox;
                CheckBox cb = this.Controls.Find("check_" + i.ToString() + "_stat", true).FirstOrDefault() as CheckBox;
                if(pb != null && cb != null)
                {
                    differences.Add(pb, cb);
                    pb.Click += Pb_Click;
                }
            }
        }
        private void Pb_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (differences.ContainsKey(pb))
            {
                CheckBox cb = differences[pb];
                cb.Checked = true;
                differences.Remove(pb);
                if (differences.Count == 0)
                {
                    MessageBox.Show("Congrats you win the game!");
                }
            }
        }
    }
