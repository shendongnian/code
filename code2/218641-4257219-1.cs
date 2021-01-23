    public static IEnumerable<Box> GetBoxesRecursive(this Box box)
    {
      if(box == null)
         throw new ArgumentNullException("box");
       
      return new[] { box }
                   .Concat((box.Contents ??  Enumerable.Empty<Box>())
                           .SelectMany(GetBoxesRecursive));       
                           // use lambda in C# 3.0                                           
    
    }
   
    ...    
    Box desiredBox = myBox.GetBoxesRecursive()
                          .FirstOrDefault(b => b.Size == desiredSize);
