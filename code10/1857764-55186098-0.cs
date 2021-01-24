class Program
    {
        public class Node
        {
            /* You add the type of bird and a count of 
             * how many times that bird is said. 
             * Then you use a method to print out 
             * the types of birds and how many times each bird was said*/
            public string bird;
            public Node next;
            public int count; // each bird needs a counter
            public Node(string i)
            {
                bird = i;
                next = null;
                count = 0;
            }
            public void getReport()
            {
                Console.Write("|" + bird + "|->" +  count );
                if (next != null)
                {
                    next.getReport();
                }
            }
            public void AddToEnd(string bird)
            {
                if (this.bird != bird) // if the bird is already in the list, it wont add it in again.
                {
                    if (next == null)
                    {
                        next = new Node(bird);
                    }
                    else
                    {
                        next.AddToEnd(bird);
                    }
                }
            }
            public class BirdList
            {
                public Node headNode;
                public BirdList()
                {
                    headNode = null;
                }
                public void AddToEnd(string bird) //method to add to the end of a list if bird is not already in the list. 
                {
                    if (headNode == null)
                    {
                        headNode = new Node(bird);
                    }
                    else
                    {
                        headNode.AddToEnd(bird);
                    }
                }
                public void AddToBeginning(string bird) //add to the beginning of a list
                {
                    if (headNode == null)
                    {
                        headNode = new Node(bird);
                    }
                    else
                    {
                        Node temp = new Node(bird);
                        temp.next = headNode;
                        headNode = temp;
                    }
                }
                public void getReport()
                {
                    if (headNode != null)
                    {
                        headNode.getReport();
                    }
                }
                public int getCount(string bird)
                {
                    Node current = headNode;
                    int count = 0;
                    while (current != null)
                    {
                        if (current.bird == bird)
                        {
                            current.count++; // once the bird is found, increment the counter.
                            count = current.count; // set the birds counter to the count.
                        }
                        current = current.next;
                    }
                   
                    return count;
                }
            }
            static void Main(string[] args)
            {
                BirdList birdList = new BirdList();
                string userInput = "";
                while (userInput != "done")
                {
                    Console.WriteLine("Please enter a bird:");
                    userInput = Console.ReadLine();
                    if (userInput == "done")
                    {
                        break;
                    }
                    birdList.AddToEnd(userInput);
                    Console.WriteLine(birdList.getCount(userInput));
                }
                birdList.getReport();
                Console.ReadLine();
            }
        }
    }
