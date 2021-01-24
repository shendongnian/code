    public class SortedIdentifier
    {
        public string Name { get; set; }
    }
    public class ListOfSortedIdentifier : List<SortedIdentifier>
    {
        public string SortedIdentifierDisplayValue
        {
            get { return this.FirstOrDefault()?.Name ?? "No Items"; }
        }
    }
