    private Image m_Img = DefaultImg;
    public Image Img
    {
      get { return m_Img; }
      set { m_Img = value; }
    }
    private static readonly Image DefaultImg = DemoChart.Properties.Resources.link;
	private void ResetImg() { Img = DefaultImg; }
	private bool ShouldSerializeImg() { return (Img != DefaultImg); }
