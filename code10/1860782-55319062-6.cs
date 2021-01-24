        public EpochBasedDateTime TimeSinceEpoch {get; set;}
    }
    var test = new Test();
    test.TimeSinceEpoch =  12345;
    DateTime dt = test.TimeSinceEpoch;
