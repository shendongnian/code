    public class DataModel2
    {
      Public DataModel2()
      {
       }
       Public DataModel2(DataModel1 model1)
       {
          Id= model1.Id;
          Name = model1.Name;
        }
      public string Id { get; set; }
      public string Name { get; set; }
      public string Phone { get; set; }
