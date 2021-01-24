    public enum Actions
    {
        delete,  // 0
        add,     // 1
        edit     // 2, you can change those by setting them like this: edit = 2
    };
    
    class Program
    {
        static void Main(string[] args)
        {
            Actions ac = (Actions) Enum.Parse(typeof(Actions), Console.ReadLine());
            switch (ac)
            {
                case Actions.delete:
                    int k = int.Parse(Console.ReadLine());
                    Delete(flights[k]);
                    Console.WriteLine("");
                    break;
                case Actions.add:
                    Add();
                    Console.WriteLine("");
                    break;
                case Actions.edit:
                    Edit();
                    Console.WriteLine("");
                    break;
                default:
                    Console.WriteLine("Incorrect number!");
                    break;
            }
        }
    }
