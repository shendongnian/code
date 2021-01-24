            List<DataClass> list = new List<DataClass>();
            list.Add(new DataClass {Number1= 1, Number2 = 100});
            list.Add(new DataClass {Number1= 2, Number2 = 100});
            list.Add(new DataClass {Number1= 3, Number2 = 101});
            list.Add(new DataClass {Number1= 4, Number2 = 102});
            list.Add(new DataClass {Number1= 5, Number2 = 103});
            list.Add(new DataClass {Number1= 6, Number2 = 104});
            list.Add(new DataClass {Number1= 7, Number2 = 104}); 
            var outPut = SplittedOutPut(list); 
    private static Dictionary<int,IList<DataClass>> SplittedOutPut(IList<DataClass> fullList)
	 {
          List<DataClass> Number1 = new List<DataClass>();
          List<DataClass> Number2 = new List<DataClass>();
		  foreach (DataClass item in fullList)
          {
            if(!Number1.Exists( _ => _.Number2 == item.Number2))
                Number1.Add(item);
            else
                Number2.Add(item); 
          }
          
        var output = new Dictionary<int, IList<DataClass>>();
        outPut.Add(1,Number1);
        outPut.Add(2,Number2);
        return output;
      }
