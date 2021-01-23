    XmlReader reader = new XmlReader("layout.xml");
    Stack<IElement> currentRoot = new Stack<IElement>();
    currentRoot.Push(root);
    while(reader.Read())
    {
        // get the element tag
        if(reader.NodeType == XmlNodeType.Element)
        {
           Debug.Assert(creators_.ContainsKey(reader.Name));  // must have it!
           IElement newElement = creators_[reader.Name].Invoke(); // create it
           newElement.LoadFromXml(reader);            // tell element to read itself in
           currentRoot.Peek().Children.Add(newElement); // add to parent
           currentRoot.Push(newElement);  // we are now new parent
        }
        else if(reader.NodeType == XmlNodeType.EndElement)
           currentRoot.Pop();  // just pop it off!
    }
