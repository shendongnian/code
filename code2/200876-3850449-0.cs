When I use the IEquatable interface on classes I normally use the following code:
    public override bool Equals(object obj)
    {
        // If obj isn't MyType then 'as' will pass in null
        return this.Equals(obj as MyType);
    }
    public bool Equals(MyType other)
    {
        if (object.ReferenceEquals(other, null))
        {
            return false;
        }
        // Actual comparison code here
        return other.ToString() == this.ToString();
    }
