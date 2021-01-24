    var jsonObject = new RootObject()
        {
            version = "1.0",
            data = new Data()
                {
                    sampleArray = new List<object>()
                        {
                            "string value",
                            5,
                            new SubData(){ name = "sub object" }
                        }
                }
        };
    var jsonString = JsonUtility.ToJson(jsonObject);
