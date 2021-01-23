    public MyLazyObject GetMyLazyObjectUsingNullCoalescingOpMethod()
    {
        _lazyObject = _lazyObject ?? new MyLazyObject();
        return _lazyObject;
    }
