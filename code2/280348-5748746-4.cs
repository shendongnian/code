        class HtmlPaginator
        {
            public event EventHandler<PageImageEventArgs> PageReady;
            protected virtual void OnPageReady(PageImageEventArgs e)
            {
                EventHandler<PageImageEventArgs> handler = this.PageReady;
                if (handler != null)
                    handler(this, e);
            }
            public class PageImageEventArgs : EventArgs
            {
                public Image PageImage { get; set; }
                public int PageNumber { get; set; }
            }
            public void GeneratePages(string doc)
            {
                Bitmap htmlImage = RenderHtmlToBitmap(doc);
                int pageWidth = 800;
                int pageHeight = 600;
                int xLoc = 0;
                int yLoc = 0;
                int pages = 0;
                do
                {
                    int remainingHeightOrPageHeight = Math.Min(htmlImage.Height - yLoc, pageHeight);
                    int remainingWidthOrPageWidth = Math.Min(htmlImage.Width - xLoc, pageWidth);
                    Rectangle cropFrame = new Rectangle(xLoc, yLoc, remainingWidthOrPageWidth, remainingHeightOrPageHeight);
                    Bitmap page = htmlImage.Clone(cropFrame, htmlImage.PixelFormat);
                    pages++;
                    PageImageEventArgs args = new PageImageEventArgs { PageImage = page, PageNumber = pages };
                    OnPageReady(args);
                    yLoc += pageHeight;
                    if (yLoc > htmlImage.Height)
                    {
                        xLoc += pageWidth;
                        if (xLoc < htmlImage.Width)
                        {
                            yLoc = 0;
                        }
                    }
                } 
                while (yLoc < htmlImage.Height && xLoc < htmlImage.Width);
            }
            private static Bitmap RenderHtmlToBitmap(string doc)
            {
                Bitmap htmlImage = null;
                using (var webBrowser = new WebBrowser())
                {
                    webBrowser.ScrollBarsEnabled = false;
                    webBrowser.ScriptErrorsSuppressed = true;
                    webBrowser.DocumentText = doc;
                    while (webBrowser.ReadyState != WebBrowserReadyState.Complete)
                    {
                        Application.DoEvents();
                    }
                    webBrowser.Width = webBrowser.Document.Body.ScrollRectangle.Width;
                    webBrowser.Height = webBrowser.Document.Body.ScrollRectangle.Height;
                    htmlImage = new Bitmap(webBrowser.Width, webBrowser.Height);
                    using (Graphics graphics = Graphics.FromImage(htmlImage))
                    {
                        var hdc = graphics.GetHdc();
                        var rect1 = new Rectangle(0, 0, webBrowser.Width, webBrowser.Height);
                        var rect2 = new Rectangle(0, 0, webBrowser.Width, webBrowser.Height);
                        var viewObject = (IViewObject)webBrowser.Document.DomDocument;
                        viewObject.Draw(1, -1, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, hdc, ref rect1, ref rect2, IntPtr.Zero, 0);
                        graphics.ReleaseHdc(hdc);
                    }
                }
                return htmlImage;
            }
        }
