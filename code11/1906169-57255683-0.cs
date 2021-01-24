 c#
[ProtoContract]
[ProtoInclude(1, typeof(PacketPerson))]
// future additional message types go here
class SomeMessageBase {}
[ProtoContract]
class PacketPerson : SomeMessageBase
{
    [ProtoMember(1)]
    public string Name{ get; set; }
    [ProtoMember(2)]
    public string Country { get; set; }
}
and deserialize/serialize `<SomeMessageBase>`. The library will deal with all the inheritence in the right way here. Behind the scenes, this will be implemented similarly to (in .proto terms):
 protobuf
message SomeMessageBase {
    oneof ActualType {
        PacketPerson = 1;
        // ...
    }
}
message PacketPerson {
    string Name = 1;
    string Country = 2;
}
You can now use either polymorphism or type testing for determining the actual type at runtime. The new `switch` syntax is especially useful:
 c#
SomeMessageBase obj = WhateverDeserialize();
switch(obj)
{
    case PacketPerson pp:
        // do something person-specific with pp
        break;
    case ...:
        // etc
        break;
}
