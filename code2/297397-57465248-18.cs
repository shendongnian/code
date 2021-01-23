    public class VariableInfo : IEquatable<VariableInfo>
    {
        public int Index { get; }
        public string Name { get; }
        public Type Type { get; }
        public VariableInfo(int index, Type type, string name) =>
            (Index, Type, Name) = (index, type, name);
        public override bool Equals(object obj) =>
            Equals(obj as VariableInfo);
        public bool Equals(VariableInfo info) =>
            info != null &&
            Index.Equals(info.Index) &&
            Name.Equals(info.Name) &&
            Type.Equals(info.Type);
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = 23 * hash + Index.GetHashCode();
                hash = 23 * hash + Name.GetHashCode();
                hash = 23 * hash + Type.GetHashCode();
                return hash;
            }
        }
        public override string ToString() =>
            $"Index {Index}, Type {Type}, Name {Name}";
    }
