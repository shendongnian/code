    public Foo PreviewDocument
    {
        get
        {
            if (!_rendered)
            {
                _originalreportingObj.Render();
                _rendered = true;
            }
            return _originalreportingObj.PreviewDocument;
        }
    }
