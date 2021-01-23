    class MyLinkedList
    {
        MyLinkedList nextNode;
        int data;
        public void OrderListBubbleAlgoritm(ref MyLinkedList head)
        {
            bool needRestart = true;
            MyLinkedList actualNode = head; //node Im working with        
            int temp;
            while (needRestart)
            {
                needRestart = false;
                actualNode = head;
                while (!needRestart && actualNode.nextNode != null)
                {
                    if (actualNode.nextNode.data >= actualNode.data) //is sorted
                    {
                        actualNode = actualNode.nextNode;
                    }
                    else
                    {
                        //swap the data
                        temp = actualNode.data;
                        actualNode.data = actualNode.nextNode.data;
                        actualNode.nextNode.data = temp;
                        needRestart = true;
                    }
                }
            }
        }
     }
