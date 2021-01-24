        {
          "topics":{
            "test1":{
            "topic":"test1",
            "partition":{...}
            },
            "test2":{
            "topic":"test2",
            "partition":{...}
           }]
        }
        class Root
        {
            public Topics test1{ get; set; }
            public Topics test2{ get; set; }
        }
        class Topics
        {
            public string topic { get; set; }
            public Partitions partitions { get; set; }
        }
