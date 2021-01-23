            string[] asLines;
            // ToDo: Add code here to populate the collection of lines to process
            // Create a base element that makes popuplation of the elements easier
            Element BaseElement = new Element("");
            // Cycle through each of the lines
            foreach (string sLine in asLines())
            {
                // Get the components out of the line
                string[] asElements = sLine.Split("|");
                // Starting with the base element
                Element oParentElement = BaseElement;
                // Cycle through each of the elements that were found, adding the current value to the parent's 
                // collection of children, then using the new or found item as the parent for the next item in the list
                for (int nI = 0; nI < asElements.Length; nI++)
                {
                    oParentElement = oParentElement.AddOrFetchChild(asElements[nI]);
                }
            }
            // Finally, add the nodes to the tree recursively
            AddNodesToTree(BaseElement.Children, this.treeView1.Nodes);
