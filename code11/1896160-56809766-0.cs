    public override bool Equals(object obj)
    {
        if(!(obj is B))
        {
            return false;
        }
        var b = obj as B;
        if(b.Prop.Count != this.Prop.Count)
        {
            return false;
        }
        for(var i =0; i < Prop.Count; i++)
        {
            if (!Prop.ElementAt(i).Equals(b.Prop.ElementAt(i)))
            {
                return false;
            }
        }
        return true;
    }
