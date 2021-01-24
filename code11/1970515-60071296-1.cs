    public class ViewModel
    {
        public List<Model> monkeyList { set; get; }
        public ViewModel()
        {
            monkeyList = new List<Model>();
            monkeyList.Add(
                new Model() {
                    Name = "Baboon"
                });
            monkeyList.Add(
               new Model()
               {
                   Name = "Capuchin"
               });
            monkeyList.Add(
               new Model()
               {
                   Name = "Squirrel"
               });
            monkeyList.Add(
               new Model()
               {
                   Name = "Howler"
               });
            monkeyList.Add(
               new Model()
               {
                   Name = null
               });
        }
    }
