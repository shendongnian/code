    public string Achstring { get; set; }
    public Image PicImage { get; set; }
    private void MessageForm_Load(object sender, EventArgs e)
    {
        achievement_lbl.Text = AchievementString;
        achievement_pic.Image = PicImage
    }
