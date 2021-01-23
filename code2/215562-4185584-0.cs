    private int? _hashCode;
    
    public override int GetHashCode()
    {
        if (!_hashCode.HasValue)
        {
            if (Id == 0)
                _hashCode.Value = base.GetHashCode();
            else
                _hashCode.Value = Id;
                // Or this when the above does not work.
                // _hashCode.Value = Id ^ GetType().GetHashCode();
        }
        
        return _hasCode.Value;
    }
