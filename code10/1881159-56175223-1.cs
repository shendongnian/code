    public class OuterList : List<InnerList>
    {
        public override string ToString()
        {
            var result = new StringBuilder();
            ForEach(inner =>
            {
                if (inner != null) result.AppendLine(inner.ToString());
            });
            return result.ToString();
        }
    }
