 proto
syntax = "proto2";
message FooA {
   optional double A = 1;
   optional double B = 2;
   oneof subtype {
      FooB FooB = 201;
      FooA1 FooA1 = 202;
   }
}
message FooA1 {
}
message FooB {
   optional double C = 1;
   oneof subtype {
      FooC FooC = 201;
   }
}
message FooC {
   oneof subtype {
      FooD FooD = 201;
   }
}
message FooD {
   optional double D = 1;
}
v2 starting from `FooA1` - `FooD` is 201, 201:
 proto
syntax = "proto2";
message FooA1 {
   optional double A = 1;
   optional double B = 2;
   oneof subtype {
      FooC FooC = 201;
   }
}
message FooC {
   optional double C = 1;
   oneof subtype {
      FooD FooD = 201;
   }
}
message FooD {
   optional double D = 1;
}
