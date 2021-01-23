    protected override void Render(HtmlTextWriter writer) 
    {
            StringBuilder sb = new StringBuilder();
            HtmlTextWriter htw = new HtmlTextWriter(new StringWriter(sb));
            base.Render(htw);
            writer.Write(sb.ToString());
            Logger.Write("TransferToColdFusion HTML: " + sb.ToString(), "Debug");
        }
    }
