    public static partial class XmlReaderExtensions
    {
        public static IEnumerable<XmlReader> ReadElements(this XmlReader reader, string localName, string namespaceURI)
        {
            reader.MoveToContent();
            if (reader.NodeType != XmlNodeType.Element)
                throw new InvalidOperationException("The reader is not positioned on an element.");
            var isEmpty = reader.IsEmptyElement;
            reader.Read();
            if (isEmpty)
                yield break;
            while (!reader.EOF)
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.EndElement:
                        yield break;
                    case XmlNodeType.Element:
                        {
                            if (reader.LocalName == localName && reader.NamespaceURI == namespaceURI)
                            {
                                using (var subReader = reader.ReadSubtree())
                                {
                                    subReader.MoveToContent();
                                    yield return subReader;
                                }
								// ReadSubtree() leaves the reader positioned ON the end of the element, so read that also.
                                reader.Read();
                            }
                            else
                            {
								// Skip() leaves the reader positioned AFTER the end of the element.
                                reader.Skip();
                            }
                        }
                        break;
                    default:
						// Not an element: Text value, whitespace, comment.  Read it and move on.
                        reader.Read();
                        break;
                }
            }
        }
    }
