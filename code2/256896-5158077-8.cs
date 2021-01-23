    using System.Runtime.Serialization;
    ...
    
            [Serializable]
            class Data {
               DateTime StartDate; 
               DateTime EndDate;
            }
        
        // or really any serializable IEnumerable
            public static MyMethod(string data) {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Data[] data = (Data[])serializer.Deserialize(data); 
                foreach (Data item in data) {
                  // do stuff
                }
            }
    
    
