    public void ConvertHtmlToImage(string html)
    {
    Bitmap m_Bitmap = new Bitmap(400, 600);
    PointF point = new PointF(0, 0);
    SizeF maxSize = new System.Drawing.SizeF(500, 500);
    HtmlRenderer.HtmlRender.Render(Graphics.FromImage(m_Bitmap),html,
                                            point, maxSize);
    m_Bitmap.Save(@"C:\MyHtml.png", ImageFormat.Png);
    }
