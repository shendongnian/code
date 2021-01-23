        static void Main(string[] args)
        {
        	const int N = 1000*1000;
			Random r = new Random();
			LinkedList<int> linkedList = new LinkedList<int>();
			List<int> list = new List<int>();
			List<LinkedListNode<int>> linkedListNodes = new List<LinkedListNode<int>>();
        	for (int i = 0; i < N; i++)
        	{
				list.Add(r.Next());
        		LinkedListNode<int> linkedListNode = linkedList.AddFirst(r.Next());
				if(r.Next() % 997 == 0)
					linkedListNodes.Add(linkedListNode);
        	}
			Stopwatch stopwatch = new Stopwatch();
        	
			stopwatch.Start();
			for (int i = 0; i < 500; i++)
			{
				linkedList.AddBefore(linkedListNodes[i], r.Next());
				linkedList.Remove(linkedListNodes[i]);
			}
        	stopwatch.Stop();
			Console.WriteLine("LinkedList 500 insert/remove operations: {0}", stopwatch.ElapsedTicks);
			stopwatch.Reset();
			stopwatch.Start();
			for (int i = 0; i < 500; i++)
			{
				list.Insert(r.Next(0,list.Count), r.Next());
				list.RemoveAt(r.Next(0, list.Count));
			}
			stopwatch.Stop();
			Console.WriteLine("List 500 insert/remove operations: {0}", stopwatch.ElapsedTicks);
        	Console.Read();
        }
    }
