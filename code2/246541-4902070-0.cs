    public class ElementClass {public int A; public int B;}
    
    ...
    
    List<ElementClass> myList = GetAListOfRandomElementClassInstances();
    
    //sorts in ascending order by A, then B
    myList.Sort((x,y)=> x.A > y.A 
                        ? 1 
                        : x.A < y.A 
                          ? -1 
                          : x.B > y.B 
                            ? 1 
                            : x.B < y.B 
                              ? -1 
                              : 0);
