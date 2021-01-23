    XmlTextReader reader = new XmlTextReader(stream);
    reader.EntityHandling = EntityHandling.ExpandCharEntities;
    XmlDocument doc = new XmlDocument();
    doc.Load(reader);
    List<XmlEntityReference> entityRefs = new List<XmlEntityReference>();
    RetrieveEntityRefs(doc.DocumentElement, doc, entityRefs);
    private void RetrieveEntityRefs(XmlNode parentNode, XmlDocument doc, List<XmlEntityReference> entityReferences) {
        foreach (XmlNode node in parentNode.ChildNodes)
        {
            if (node.NodeType == XmlNodeType.EntityReference) {
                XmlEntityReference entityRef = node as XmlEntityReference;
                entityReferences.Add(entityRef);
            }
            else if (node.HasChildNodes) {
                RetrieveEntityRefs(node, doc, entityReferences);
            }
        }
    }
