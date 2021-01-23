    public class EnsureMinimumElementsAttribute : ValidationAttribute
    {
        public int MinElements { get; set; }
        public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list != null)
            {
                return list.Count >= MinElements;
            }
            return false;
        }
    }
