        public enum Actions
        {
             delete,
             add,
             edit
        };
      public void Main() 
      {
        Actions ac = (Actions) Enum.Parse(typeof(Actions), Console.Readline());
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
