    class StringAndHash
    {
        public int HashCode;
        public string Value;
        public StringAndHash(string value)
        {
            if (value == null)
                HashCode = 0;
            else
                HashCode = StringComparer.Ordinal.GetHashCode(value.GetHashCode());
            Value = value;
        }
        public static implicit operator string(StringAndHash value)
        {
            return value.Value;
        }
        public static implicit operator StringAndHash(string value)
        {
            return new StringAndHash(value);
        }
        public override int GetHashCode()
        {
            return HashCode;
        }
        public override bool Equals(object obj)
        {
            var sah = obj as StringAndHash;
            if (!object.ReferenceEquals(sah, null))
            {
                return Equals(sah);
            }
            return base.Equals(obj);
        }
        public override bool Equals(StringAndHash obj)
        {
            return obj.HashCode == HashCode // This will improve perf in negative cases.
                && StringComparer.Ordinal.Equals(obj.Value, Value);
        }
    }
    public Dictionary<string, StringAndHash[]> blockProperty;
    bool BlockMatch(IList<StringAndHash> container, string block, int cut)
    {
        var blockArray = blockProperty[block];
        var length = blockArray.Length - cut;
        if (length > container.Count)
        {
            return false;
        }
        for (int i = cut; i < blockArray.Length; i++)
        {
            if (blockArray[i].Equals(container[i]))
            {
                return false;
            }
        }
        return true;
    }
