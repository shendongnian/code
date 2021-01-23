    class Class1
    {
        public class Node()
        {
            public int Data;
            public Node Next;
            //Class to set next node
            public void setNext(Node nextNode)
            {
               //Set next node
               Next = nextNode;
            }
            //Get next node
            public Node getNext()
            { 
               return Next;
            }
        }
        private Node FirstNode=null;
        private Node lastNode = null;
        public void AddBefore(int number)        
        {
            Node NewNode=new Node();
            NewNode.Next=FirstNode;
            NewNode.Data=number;
            FirstNode=NewNode;
        }
        public void AddAfter(int number)
        {
            if (FirstNode==null)
            {
                AddBefore(number);
            }
            else
            {                    
                if(FirstNode.getNext() == null)
                {
                   //No tail. Make this node tail
                   lastNode = new Node();
                   lastNode.Data = number;
                   //Set first node's next to last node
                   FirstNode.setNext(lastNode);
                }else{ //TailNode already set
                   //New node to be tail
                   Node newLastNode = new Node();
                   newLastNode.Data = number;
                   //Set the current tail node to have this node as next
                   lastNode.setNext(newLastNode);
                   //Make new last node last node
                   lastNode = newLastNode;
                }
            }
        } 
     }
