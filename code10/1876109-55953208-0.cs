        public double GetMigraHeightPosition()
        {
            MigraDoc.Rendering.DocumentRenderer docRenderer = new DocumentRenderer(this.document);
            docRenderer.PrepareDocument();
            RenderInfo[] RenderInfos = docRenderer.GetRenderInfoFromPage(docRenderer.FormattedDocument.PageCount);
            RenderInfo r = RenderInfos[RenderInfos.Count() - 1];
            return r.LayoutInfo.ContentArea.Y + r.LayoutInfo.ContentArea.Height;
        }
