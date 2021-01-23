    var result = (from t in MyContext.MyItems
                 select new
                 {
                     FirstProperty = t
                 })
                 .AsEnumerable() 
                 .Select(t => new MyViewModelClass()
                 {
                     FirstProperty = t.FirstProperty ,
                     SecondProperty = new SomeLinq2SqlEntity();
                 });   
  
