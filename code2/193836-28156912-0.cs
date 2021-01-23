    private void SwapXNodes(bool up, int inUniqueID)
        {
            XElement currNode = DocumentManager.xMainDocument.XPathSelectElement("//*[@UniqueID='" + inUniqueID + "']"); // find 
            
            if (up)
            {
                if (currNode.PreviousNode != null)
                {
                    XElement xPrevious = new XElement((XElement)currNode.PreviousNode); // copy of previous node
                    currNode.PreviousNode.ReplaceWith(currNode); // previous node equal to me
                    currNode.ReplaceWith(xPrevious); // Now I should be equal to previous node
                }
            }
            else
            {
                if (currNode.NextNode != null)
                {
                    XElement xNext = new XElement((XElement)currNode.NextNode); // copy of Next node
                    currNode.NextNode.ReplaceWith(currNode); // Next node equal to me
                    currNode.ReplaceWith(xNext); // Now I should be equal to Next node copy
                }
            }
        }
