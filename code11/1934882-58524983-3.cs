    using System;
    using example;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Example e = new Example(2.0);
                Controllable i = new Controllable
                {
                    target = e
                };
                i.Start();
    
                solution2.examplechild derivedClass = new solution2.examplechild();
                derivedClass.Start();
                solution2.Controllable controllable = new solution2.Controllable();
                controllable.Start();
    
                Console.WriteLine("controllable is selected               :   " + i.isSelected.ToString() + " should be : "+ true.ToString());
                Console.WriteLine("contrallable is selected in solution   :   " + controllable.isSelected.ToString() + " should be : " + false.ToString());
                Console.WriteLine("derivedClass is selected in solution   :   " + derivedClass.isSelected.ToString() + " should be : " + true.ToString());
            }
        }
    }
