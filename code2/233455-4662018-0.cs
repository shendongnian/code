    bool Equal(object a, object b)
    {
        // They're both null.
        if (a == null && b == null) return true;
        // One is null, so they can't be the same.
        if (a == null || b == null) return false;
        // How can they be the same if they're different types?
        if (a.GetType() != b.GetType()) return false; 
        var Props = a.GetType().GetProperties();
        foreach(var Prop in Props)
        {
            // See notes *
            var aPropValue = Prop.GetValue(a) ?? string.Empty;
            var bPropValue = Prop.GetValue(b) ?? string.Empty;
            if(aPropValue.ToString() != bPropValue.ToString())
                return false;
        }
        return true;
    }
