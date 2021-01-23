    using (var buffer = new MemoryStream())
    {
        var builder = new System.IO.StreamWriter(buffer);
        using (var stream = new HtmlTextWriter(builder))
        {
            holder.RenderControl(stream);
        }
        return builder.ToString();
    }
