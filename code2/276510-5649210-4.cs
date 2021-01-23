                List<int> t;
                t = Enumerable.Range(1, 100).ToList();
    
                var fizzBuzz = t.Where(num => num % 3 == 0 && num % 5 == 0);
                var fizz = t.Where(num => num % 3 == 0);
                var buzz = t.Where(num => num % 5 == 0);
                var notFizzBuzz = t.Where(num => num % 3 != 0 && num % 5 !=0);
    
                //print fizzBuzz elements
                Console.WriteLine("Printing fizzBuzz elements...");
                foreach (int i in fizzBuzz)
                    Console.WriteLine(i);
    
                //print fizz elements
                Console.WriteLine("Printing fizz elements...");
                foreach (int i in fizz)
                    Console.WriteLine(i);
    
                //print buzz elements
                Console.WriteLine("Printing buzz elements...");
                foreach (int i in buzz)
                    Console.WriteLine(i);
    
                //print other elements
                Console.WriteLine("Printing all others...");
                foreach (int i in notFizzBuzz)
                    Console.WriteLine(i);
