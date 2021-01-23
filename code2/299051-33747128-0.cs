        var itemHeight = 36;
        var verticalPadding = 36 - TextRenderer.MeasureText("A", _DisplayNameFont).Height) / 2;
        menu.Renderer = new MyRenderer { VerticalPadding = verticalPadding };
        class MyRenderer : ToolStripSystemRenderer
        {
            public int VerticalPadding { get; set; }
            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                if (null == e)
                { return; }
                e.TextFormat &= ~TextFormatFlags.HidePrefix;
                e.TextFormat |= TextFormatFlags.VerticalCenter;
                var rect = e.TextRectangle;
                rect.Offset(0, VerticalPadding);
                e.TextRectangle = rect;
                base.OnRenderItemText(e);
            }
        }
