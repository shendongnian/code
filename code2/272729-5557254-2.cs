    public void RemoveAllData(int data)
    {
        while (m_HeadNode != null && m_HeadNode.data == data)
        {
            m_HeadNode = m_HeadNode.m_NextNode;
        }
        if(m_HeadNode != null)
        {
            Node previous = m_HeadNode;
            Node current = m_HeadNode.m_NextNode;
            while (current != null)
            {
                if (current.data == data)
                {
                    // If we're removing the last entry in the list, current.Next
                    // will be null. That's OK, because setting previous.Next to 
                    // null is the proper way to set the end of the list.
                    previous.m_NextNode = current.m_NextNode;
                    // If we remove the current node, then we don't need to move
                    // forward in the list. The reference to previous.Next, below,
                    // will now point one element forward than it did before.
                }
                else
                {
                    // Only move forward in the list if we actually need to, 
                    // if we didn't remove an item.
                    previous = current;
                }
                current = previous.m_NextNode;
            } 
        }
    }
