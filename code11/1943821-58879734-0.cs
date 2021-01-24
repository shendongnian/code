    public override string GetHash()
    {
        var output = 0;
        foreach (Vector3 val in this.v)
        {
            output = output ^ val.GetHashCode();
        }
        
        foreach (Vector3 val in this.n)
        {
            output = output ^ val.GetHashCode();
        }
        foreach (Vector2 val in this.u)
        {
            output = output ^ val.GetHashCode();
        }
        foreach (int val in this.t)
        {
            output = output ^ val.GetHashCode();
        }
        return output.ToString();
    }
