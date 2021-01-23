    public class XmlDataReader<T> : IEnumerable, IDisposable
    {
        private readonly XmlTextReader reader = null;
        public XmlDataReader(string filename)
        {
            reader = new XmlTextReader(filename) {WhitespaceHandling = WhitespaceHandling.None};
            reader.MoveToContent();     // Go to root node.
            reader.Read();              // Go to first child node.
        }
        #region Implementation of IEnumerable
        public IEnumerator GetEnumerator()
        {
            if (reader == null) yield break;
            do
            {
                var ser = new XmlSerializer(typeof (T));
                var subTree = reader.ReadSubtree();
                subTree.MoveToContent();
                var node = ser.Deserialize(subTree);
                subTree.Close();
                yield return node;
                reader.Skip();
            } while (!reader.EOF && reader.IsStartElement());
        }
        #endregion
        #region Implementation of IDisposable
        public void Dispose()
        {
            if (reader != null)
                reader.Close();
        }
        #endregion
    }
