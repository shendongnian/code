    Int[] number ={1,2,3,4,5,6,7,8,9,10};
    Int? Result = null;
     foreach(Int i in number)
    
        {
           If(!Result.HasValue || i< Result)
        
            { 
    
                Result =i;
             }
         }
      
         Console.WriteLine(Result);
       }
