    try
    {
        _declaredencoding = Encoding.GetEncoding(charset);
    }
    catch (ArgumentException)
    {
        _declaredencoding = null;
    }
    if (_onlyDetectEncoding)
    {
        throw new EncodingFoundException(_declaredencoding);
    }
    if (_streamencoding != null)
    {
        if (_declaredencoding.WindowsCodePage != _streamencoding.WindowsCodePage)
        {
            AddError(
                HtmlParseErrorCode.CharsetMismatch,
                _line, _lineposition,
                _index, node.OuterHtml,
                "Encoding mismatch between StreamEncoding: " +
                _streamencoding.WebName + " and DeclaredEncoding: " +
                _declaredencoding.WebName);
        }
    }
