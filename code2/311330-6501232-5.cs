    public class Program{
        public static void Main(){
	   var someObject = new SomeObject { 
							Name = "Composite",
							SomeObjects = new List<SomeObject>{
								new SomeObject{ Name = "Leaf 1" },
								new SomeObject{ 
								    Name = "Nested Composite",
									SomeObjects = new List<SomeObject>{ new SomeObject{Name = "Deep Leaf" }}
								}
							}
						};
	   someObject.TraverseAndExecute(      
                          x => x.SomeObjects, 
                          x => { Console.WriteLine("Name: " + x.Name); }
           );
        }
    }
