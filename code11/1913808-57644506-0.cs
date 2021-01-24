           public void AddToIndex(int element, int index)
            {
                DNode temp = new DNode(element);
                DNode temp1=Head;
                for (int i = 1; i < index - 1; i++)
                {
                    temp1 = temp1.next;
                }
                temp.next=temp1.next
                temp1.next=temp            
            }
