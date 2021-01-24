    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(Exp));  
       ExpbsObj2 = (Exp)deserializer.ReadObject(ms); 
    ExpbsObj2.A = "A1";
    ExpbsObj2.B = "B1";
    ExpbsObj2.C = "C1";
    ExpbsObj2.D = "D1";
    string output = JsonConvert.SerializeObject(ExpbsObj2);
