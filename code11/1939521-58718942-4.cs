    public static partial class XmlReaderExtensions
    {
        /// <summary>
        /// Read all immediate child elements of the current element, and yield return a reader for those matching the incoming name & namespace.
        /// Leave the reader positioned after the end of the current element
        /// </summary>
        public static IEnumerable<XmlReader> ReadElements(this XmlReader inReader, string localName, string namespaceURI)
        {
            inReader.MoveToContent();
            if (inReader.NodeType != XmlNodeType.Element)
                throw new InvalidOperationException("The reader is not positioned on an element.");
            var isEmpty = inReader.IsEmptyElement;
            inReader.Read();
            if (isEmpty)
                yield break;
            while (!inReader.EOF)
            {
                switch (inReader.NodeType)
                {
                    case XmlNodeType.EndElement:
                        // Move the reader AFTER the end of the element
                        inReader.Read();
                        yield break;
                    case XmlNodeType.Element:
                        {
                            if (inReader.LocalName == localName && inReader.NamespaceURI == namespaceURI)
                            {
                                using (var subReader = inReader.ReadSubtree())
                                {
                                    subReader.MoveToContent();
                                    yield return subReader;
                                }
                                // ReadSubtree() leaves the reader positioned ON the end of the element, so read that also.
                                inReader.Read();
                            }
                            else
                            {
                                // Skip() leaves the reader positioned AFTER the end of the element.
                                inReader.Skip();
                            }
                        }
                        break;
                    default:
                        // Not an element: Text value, whitespace, comment.  Read it and move on.
                        inReader.Read();
                        break;
                }
            }
        }
        /// <summary>
        /// Read all immediate descendant elements of the current element, and yield return a reader for those matching the incoming name & namespace.
        /// Leave the reader positioned after the end of the current element
        /// </summary>
        public static IEnumerable<XmlReader> ReadDescendants(this XmlReader inReader, string localName, string namespaceURI)
        {
            inReader.MoveToContent();
            if (inReader.NodeType != XmlNodeType.Element)
                throw new InvalidOperationException("The reader is not positioned on an element.");
            using (var reader = inReader.ReadSubtree())
            {
                while (reader.ReadToFollowing(localName, namespaceURI))
                {
                    using (var subReader = inReader.ReadSubtree())
                    {
                        subReader.MoveToContent();
                        yield return subReader;
                    }
                }
            }
            // Move the reader AFTER the end of the element
            inReader.Read();
        }
    }
