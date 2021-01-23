    public MyLazyObject GetMyLazyObjectUsingMoreCommonMethod()
    {
        if (_lazyObject == null)
            _lazyObject = new MyLazyObject();
        return _lazyObject;
    }
