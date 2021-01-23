                HttpContext.Current.Response.ClearHeaders();
                HttpContext.Current.Response.AppendHeader("Content-Length", dataLength.ToString());
            HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary");
            HttpContext.Current.Response.AppendHeader("Accept-Ranges", "bytes");
            if (dataLength > -1)
                HttpContext.Current.Response.AppendHeader("Accept-Header", dataLength.ToString());
            HttpContext.Current.Response.AppendHeader("Content-Disposition", string.Format("Attachment;Filename=\"{0}\"", fileName));
            HttpContext.Current.Response.ContentType = contentType;
            HttpContext.Current.Response.ClearContent();
