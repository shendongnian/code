    public static IEnumerable<Box> GetBoxesRecursive(this Box box)
    {
      if(box == null)
          throw new ArgumentNullException("box");
      var children = box.Contents ?? Enumerable.Empty<Box>();
                 
                               // use lambda in C# 3.0      
      var recursiveChildren = children.SelectMany(GetBoxesRecursive);  
       
      return new[] { box }.Concat(recursiveChildren);                                    
    }
   
    ...    
    Box desiredBox = myBox.GetBoxesRecursive()
                          .FirstOrDefault(b => b.Size == desiredSize);
