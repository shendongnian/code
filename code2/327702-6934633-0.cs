    public IEnumerable<XElement> GetRevisedVariationOverTime(IEnumerable<XElement> items)
    {
        foreach ( var item in items ) {
            if ( sampleSize < RequiredSampleSize) {
                yield return GetItemReplacement( item );
            }
            else {
                // return item as-is
                yield return item;
            }
        }
    }
    XElement GetItemReplacement( XElement item )
    {
        // modify item in-place and return it, 
        // or create a whole new XElement and return that instead...
    }
