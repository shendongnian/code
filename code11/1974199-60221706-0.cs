 c#
[ProtoContract]
public class Foo {
    [ProtoMember(12)]
    public List<DateTime> Times { get; } = new List<DateTime>();
}
then `GetProto<T>()` in both v2.3.2 (the version mentioned in the question) and v2.4.4 (the current default version) generate:
 protobuf
syntax = "proto2";
import "protobuf-net/bcl.proto"; // schema for protobuf-net's handling of core .NET types
message Foo {
   repeated .bcl.DateTime Times = 12;
}
So *on the surface of it*, it should already be just fine. If you're doing something more exotic (perhaps using a list in a dictionary value?), I'd be happy to help, but I'm going to need more of a clue as to what you're doing. Posting some C# that shows the thing you're seeing would be a great place to start.
---
Note that when protobuf-net first came around, there was no agreed transmission format for date/time-like values, so protobuf-net made something up, but it turns out to *not* be a convenient fit for cross-platform work; the following is a hard breaking change (it is **not** data compatible), but if possible, I would strongly recommend the well-known format that Google added later:
 c#
[ProtoContract]
public class Foo {
    [ProtoMember(12, DataFormat = DataFormat.WellKnown)]
    public List<DateTime> Times { get; } = new List<DateTime>();
}
which generates:
 protobuf
syntax = "proto2";
import "google/protobuf/timestamp.proto";
message Foo {
   repeated .google.protobuf.Timestamp Times = 12;
}
