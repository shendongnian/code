    private Token GetNamedToken(Token t, string name)
    {
        return new NamedToken {Value = t.Value, Name = name};
    }
    private class NamedToken : Token
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
