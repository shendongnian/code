class Something
{
    private static List<tblFingerprint> _fingerprints;
    public void Do()
    {
        DbContext context = ...
        if( _fingerprints is null )
        {
            _fingerprints = context.tblFingerprints.ToList();
        }
        // do stuff with `_fingerprints`
    }
}
