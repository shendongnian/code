	public static iText.Layout.Renderer.TableRenderer addTableToPage(PdfDocument pdfDocument, int pageNum, Rectangle rectangle, iText.Layout.Renderer.TableRenderer renderer)
	{
		PdfPage page = pdfDocument.GetPage(pageNum);
		PdfCanvas pdfCanvas = new PdfCanvas(page.NewContentStreamAfter(), page.GetResources(), pdfDocument);
		Canvas canvas = new Canvas(pdfCanvas, pdfDocument, rectangle);
		canvas.GetRenderer().GetCurrentArea();
		renderer.SetParent(canvas.GetRenderer());
		iText.Layout.Layout.LayoutResult layoutResult = renderer.Layout(new iText.Layout.Layout.LayoutContext(new iText.Layout.Layout.LayoutArea(pageNum, rectangle)));
		iText.Layout.Renderer.IRenderer rendererToAdd = layoutResult.GetStatus() == iText.Layout.Layout.LayoutResult.FULL ? renderer : layoutResult.GetSplitRenderer();
		rendererToAdd.Draw(new DrawContext(pdfDocument, pdfCanvas));
		return layoutResult.GetStatus() != iText.Layout.Layout.LayoutResult.FULL ? (iText.Layout.Renderer.TableRenderer)layoutResult.GetOverflowRenderer() : null;
	}
