    _context.Response.StatusCode = 206;
    _context.Response.AddHeader("Content-Range", string.Format("bytes {0}-{1}/{2}", lower.ToString(), upper.ToString(), view.Content.Length.ToString()));
    _context.Response.AddHeader("Content-Length", length.ToString());
    _context.Response.AddHeader("Accept-Ranges", "bytes");
    _context.Response.OutputStream.Write(view.Content.ToArray(), lower, length);
