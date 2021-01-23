    BoxEqualityComparer boxEqC = new BoxEqualityComparer(); 
     
    Dictionary<Box, String> boxes = new Dictionary<Box, string>(boxEqC); 
     
    Box redBox = new Box(100, 100, 25);
    Box blueBox = new Box(1000, 1000, 25);
    
    boxes.Add(redBox, "red"); 
    boxes.Add(blueBox, "blue"); 
    
