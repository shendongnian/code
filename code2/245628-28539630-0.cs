	public SyntaxHighlightBox() {
		InitializeComponent();
		MaxLineCountInBlock = 100;
		LineHeight = FontSize * 1.3;
		totalLineCount = 1;
		blocks = new List<InnerTextBlock>();
		// The Loaded handler is not needed anymore.
		SizeChanged += (s, e) => {
			if (e.HeightChanged == false)
				return;
			UpdateBlocks();
			InvalidateVisual();
		};
		TextChanged += (s, e) => {
			UpdateTotalLineCount();
			InvalidateBlocks(e.Changes.First().Offset);
			InvalidateVisual();
		};
	}
	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		// OnApplyTemplate() is called after Loaded, and this is where templated parts should be retrieved.
		renderCanvas = (DrawingControl)Template.FindName("PART_RenderCanvas", this);
		lineNumbersCanvas = (DrawingControl)Template.FindName("PART_LineNumbersCanvas", this);
		scrollViewer = (ScrollViewer)Template.FindName("PART_ContentHost", this);
		lineNumbersCanvas.Width = GetFormattedTextWidth(string.Format("{0:0000}", totalLineCount)) + 5;
		scrollViewer.ScrollChanged += OnScrollChanged;
		InvalidateBlocks(0);
		InvalidateVisual();
	}
