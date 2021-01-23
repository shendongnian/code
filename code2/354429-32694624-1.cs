        message EmbeddedPoco {
           optional int32 Id = 1;
           optional string Name = 2;
        }
        message MyPoco {
           repeated EmbeddedPoco Containers = 1;
           optional int32 IntegerProperty = 2;
           optional string StringProperty = 3;
        }
