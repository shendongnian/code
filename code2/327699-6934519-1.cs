    public IEnumerable<XElement> GetRevisedVariationOverTime(IEnumerable<XElement> items)
    {
        foreach(XElement item in items.ToList()) // note the ToList() call here
        {
            if(sampleSize < RequiredSampleSize)
            {
                item.Attribute("Status").Value = DiagStatus.WARNING.ToString();
                var newItem = getItemReplacement(item);
                setErrorOnItem(ref newItem, ...);
                // do the replacement
                item.Parent.ReplaceWith(newItem);
            }
        }
    }
