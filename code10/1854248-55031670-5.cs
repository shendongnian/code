    using System.Collections.Generic;
    
    Dictionary<string, County> Counties = new Dictionary<string, County>();
    //add County to dictionary
    Counties.Add("NorthernIreland", new County(2630000, "NorthernIreland", "Connacht", "Munster", "Wales", 0));
    //get County from dictionary
    Counties["NorthernIreland"] //and do something with it...
