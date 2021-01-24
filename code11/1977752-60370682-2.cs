    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    string jsonString = "{\"itemList\":[{\"id\":1,\"name\":\"Item 1 Name\"},{\"id\":2,\"name\":\"Item 2 Name\"}],\"listInfo\":{\"info1\":1,\"info2\":\"bla\"}}";
    BaseClass toCompare = JsonConvert.DeserializeObject<BaseClass>(jsonString);
    string itemList = JsonConvert.SerializeObject(toCompare.itemList);
    string listInfo = JsonConvert.SerializeObject(toCompare.listInfo);
