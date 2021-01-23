    using (StreamWriter sw = new StreamWriter(_viewContext.HttpContext.Response.OutputStream))
    {
        using (TextWriter textWriter = TextWriter.Synchronized(sw))
        {
            textWriter.Write(_tag.ToString(TagRenderMode.EndTag));
        }
    }
