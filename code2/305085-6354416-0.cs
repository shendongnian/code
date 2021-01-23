            List<double> myList = new List<double>();
            myList.Add(0.1234);
            myList.Add(99);
            myList.Add(12.1234);
            myList.Add(54.98);
            foreach (double d in myList)
            {
                string First = string.Format("{0:0.00%}", d); //Multiply value by 100
                Console.WriteLine(First);                    
                string Second = string.Format("{0:P}", d);//Multiply value by 100
                Console.WriteLine(Second);  
                string Third = string.Format("{0:P}%", d.ToString());//Use this One 
                Console.WriteLine(Third);  
                string Four = d.ToString() + "%"; //Not a good idea but works
                Console.WriteLine(Four);
                Console.WriteLine("=====================");  
            }
            Console.ReadLine();
