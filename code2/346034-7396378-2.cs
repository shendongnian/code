    var output = GetMyListOfSomeBigExternalDTO().Select( x=> new MyResult()
                 {
                    UserId = item.UserId, 
                    ResultValue = x.SomeIntValue
                 });
    var output2 = GetMyListOfSomeBigExternalDTO().Select( x=> new MyResult()
                 {
                    UserId = item.UserId, 
                    ResultValue = x.SomeNestedObject.NestedIntValue
                 });
         
