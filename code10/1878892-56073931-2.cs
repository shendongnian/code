        {
          "topics":[{
            "topic":"test1",
            "partition":{...}
            },{
            "topic":"test2",
            "partition":{...}
           }]
        }
        class Root
        {
            public List<Topics> topics { get; set; }
        }
        class Topics
        {
            public string topic { get; set; }
            public Partitions partitions { get; set; }
        }
