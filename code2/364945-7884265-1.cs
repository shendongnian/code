    class Program
        {
            static void Main(string[] args)
            {
                //create an list of 4 student names
                List<string> names = new List<string>(4);
                names.Add("Matt");
                names.Add("Mark");
                names.Add("Luke");
                names.Add("John");
    
                //create a list of 4 integers representing marks
                List<decimal> marks = new List<decimal>(4);
                marks.Add(88m);
                marks.Add(90m);
                marks.Add(55m);
                marks.Add(75m);
    
    
                addTwo(marks);
    
                Console.WriteLine("the mark of " + names[0] + " is : " + marks[0]);
                Console.ReadLine();
    
                Console.Read();
    
            }
    
            public static void addTwo(List<decimal> mark)
            {
                List<decimal> temp = mark;
                for (int i = 0; i < temp.Count; i++)
                {
                    temp[i] += 2m;
                }
    
            }
        }
