    using System.Collections;
    using System.Linq;
    
    
    ArrayList inputList = new ArrayList();
    ArrayList outputList = new ArrayList();
    inputList.Add(1);
    inputList.Add(2);
    inputList.Add(3);
    inputList.Add(1);
    
    inputList.ToArray().Distinct().ToList()
                .ForEach(a => outputList.Add(a));
