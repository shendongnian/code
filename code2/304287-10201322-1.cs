    public override void OnEndPage(PdfWriter writer, Document document)
    {
		base.OnEndPage(writer, document);
        var content = writer.DirectContent;
        var pageBorderRect = new Rectangle(document.PageSize);
        pageBorderRect.Left += document.LeftMargin;
        pageBorderRect.Right -= document.RightMargin;
        pageBorderRect.Top -= document.TopMargin;
        pageBorderRect.Bottom += document.BottomMargin;
        content.SetColorStroke(BaseColor.RED);
        content.Rectangle(pageBorderRect.Left, pageBorderRect.Bottom, pageBorderRect.Width, pageBorderRect.Height);
        content.Stroke();
	}
