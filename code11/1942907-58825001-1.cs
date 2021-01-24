 c#
[ProtoMember(..., DataFormat = DataFormat.WellKnown)]
on your `DateTime` / `TimeSpan` usages; this makes protobuf-net use the "well known" timestamp and duration layouts instead of the default format. The reason it doesn't do this automatically is that they (timestamp/duration) didn't exist back when protobuf-net first had to decide on *some* layout for them.
Note, however, that adding this is a breaking change: the layouts are not compatible.
If you *need* to use the legacy layout, they are described/defined in [`bcl.proto`](https://github.com/protobuf-net/protobuf-net/blob/master/src/Tools/bcl.proto).
Alternatively, in protobuf-net v3, there are explicit types for timestamp / duration, if you prefer.
---
Given the discussion (comments), frankly it looks like you are either not populating the array correctly, or are leaking that array between contexts. Testing locally, *it looks fine* - the following demo shows it working (with your `struct_tick`), including a breakdown of the binary data that shows seconds/nanos that look correct.
 c#
using ProtoBuf;
using System;
using System.IO;
class Program
{
    
    static void Main()
    {
        var payload = new struct_tick(2, 2, 2);
        payload.arr_currentIndex[0] = 12;
        payload.arr_currentIndex[1] = 14;
        payload.arr_currentType[0] = "abc";
        payload.arr_currentType[1] = "def";
        payload.arr_currentTime[0] = new DateTime(2019, 11, 12, 21, 59, 39, 745, DateTimeKind.Utc);
        payload.arr_currentTime[1] = new DateTime(2019, 11, 12, 23, 38, 50, 385, DateTimeKind.Utc);
        var ms = new MemoryStream();
        Serializer.Serialize(ms, payload);
        var hex = BitConverter.ToString(ms.GetBuffer(), 0, (int)ms.Length);
        Console.WriteLine(hex);
        ms.Position = 0;
        var clone = Serializer.Deserialize<struct_tick>(ms);
        foreach(var time in clone.arr_currentTime)
            Console.WriteLine(time); // writes 12/11/2019 21:59:39 and 12/11/2019 23:38:50
        // hex is 08-0C-08-0E-12-03-61-62-63-12-03-64-65-66-
        //        1A-0C-08-CB-D6-AC-EE-05-10-C0-98-9F-E3-02-
        //        1A-0C-08-8A-85-AD-EE-05-10-C0-C4-CA-B7-01
        // 08-0C = field 1, 12
        // 08-0E = field 1, 14
        // 12-03-61-62-63 = field 2, "abc"
        // 12-03-64-65-66 = field 2, "def"
        // 1A-OC = field 3, length 12
        //    08-CB-D6-AC-EE-05 = field 1, 1573595979 = seconds
        //    10-C0-98-9F-E3-02 = field 2, 745000000 = nanos
        // 1A-OC = field 3, length 12
        //    08-8A-85-AD-EE-05 = field 1, 1573601930 = seconds
        //    10-C0-C4-CA-B7-01 = field 2, 385000000 = nanos
    }
}
[ProtoContract]
public struct struct_tick
{
    [ProtoMember(1)]
    public uint[] arr_currentIndex;
    [ProtoMember(2)]
    public string[] arr_currentType;
    [ProtoMember(3, DataFormat = DataFormat.WellKnown)]
    public DateTime[] arr_currentTime;   // <- for DateTime.Now objects
    public struct_tick(byte size_index, byte size_type, byte size_time)
    {
        arr_currentIndex = new uint[size_index];
        arr_currentType = new string[size_type];
        arr_currentTime = new DateTime[size_time];
    }
}
