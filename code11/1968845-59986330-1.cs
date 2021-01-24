    List<Worker> Workers = new List<Workers>();
    int Worker = 1;
    for (int i = Worker; i < 5; i++)  
    {
    	Console.WriteLine("Enter name for Worker {0}", Worker);
    	name = Console.ReadLine();
    	Console.WriteLine("Enter age for Worker {0}", Worker);
    	age = Convert.ToInt32(Console.ReadLine());
    	Console.WriteLine("Enter number of sales for Worker {0}", Worker);
    	nOfSales = Convert.ToInt32(Console.ReadLine());
    	Worker worker = new Worker(name, age, nOfSales);
    	Workers.Add(worker);
    }
