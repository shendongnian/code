    public static void Main()
    {
        string content = @"{   
                            ""content"": {
                                ""table"": [
                                    {
                                        ""data"": [
                                            ""154"",
                                            ""124254"",
                                            ""87575""             
                                        ]
                                    }           
                                  ]
                                }
                            }";
         
        var result = JsonConvert.DeserializeObject<MyObject>(content);
        foreach (var table in result.Content.Tables)
        { 
            Console.WriteLine(JsonConvert.SerializeObject(table));
        }
        Console.ReadLine();
    }
