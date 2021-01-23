    private readonly List<string> _S3 = new List<string>();
    // You'll need to initialize this in your constructor, as
    // _S3View = new ReadOnlyCollection<string>(_S3);
    private readonly ReadOnlyCollection<string> _S3View;
    // TODO: Document that this is read-only, and the circumstances under
    // which the underlying collection will change
    public IList<string> S3
    {
        get { return _S3View; }
    }
