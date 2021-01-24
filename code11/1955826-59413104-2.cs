    public class MyRule : Rule {
    
      public override Boolean IsSatisfied(Data data, DataType dataType) 
      {
    	  Console.WriteLine("MyRule: Dataname:{0}, DataTypeName: {1}", data.DataName, dataType.DataTypeName);
    	  return false;
      }
    
    }
