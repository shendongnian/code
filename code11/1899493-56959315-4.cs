    class MyStripLine : StripLine
    {
        new public string Name { get; set;  }  // looks fine butwon't get serialized
        public string ID{ get; set;  }         // gets serialized
        //..
        public MyStripLine()
        {
        }
    }
