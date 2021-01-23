    public class NoteChart
    {
        public SimFile Parent { get; private set; }
        public string Id { get; private set; }
        // internal: code outside this assembly cannot instantiate this class
        internal NoteChart(SimFile parent, string id)
        {
            this.Parent = parent;
            this.Id = id;
            Parent.dictionary.Add(id, this);
        }
    }
    // Implement only IEnumerable, as that is read-only;
    // all the other collection interfaces are writable
    public class SimFile : IEnumerable<KeyValuePair<string, NoteChart>>
    {
        // internal: not accessible to code outside this assembly
        internal Dictionary<string, NoteChart> dictionary =
            new Dictionary<string, NoteChart>();
        // Public method to enable the creation of a new note chart
        // that is automatically associated with this SimFile
        public NoteChart CreateNoteChart(string id)
        {
            NoteChart noteChart = new NoteChart(this, id);
            return noteChart;
        }
        // Read-only methods to retrieve the data. No writable methods allowed.
        public NoteChart this[string index] { get { return dictionary[index]; } }
        public IEnumerator<KeyValuePair<string, NoteChart>> GetEnumerator() {
            return dictionary.GetEnumerator(); }
        public int Count { get { return dictionary.Count; } }
        public IEnumerable<string> Keys { get { return dictionary.Keys; } }
        public IEnumerable<NoteChart> Values { get { return dictionary.Values; } }
    }
