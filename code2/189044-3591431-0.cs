    public override object DataSource
    {
        get { return base.DataSource; }
        set
        {   
            // Throws an exception if the cast won't work.
            var genenum = (IEnumerable<string>)value;
            // Non-generic enumerable collection, if generic is not necessary.
            // Still throws an exception if the cast is invalid.
            var nongenenum = (IEnumerable)value;
            // Alternatively, you can use a defensive type cast, and manually
            // throw an exception if the result is null or not able to be casted.
            var safeenum = value as IEnumerable<string>;
            if(safeenum == null) throw new ArgumentException();
            // or...
            if(!(value is IEnumerable<string>)) throw new ArgumentException();
            // ... Do stuff with the enumerable.
            base.DataSource = value;
        }
    }
