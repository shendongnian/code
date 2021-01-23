    var r = new Record();
    // When Id is null, Record is empty since it has no other fields.
    // Explicitly setting Id to null will have the same effect as
    // never setting it at all.
    r.Id = null;
    r.ToByteArray(); // => byte[0]
    // Since NullableInt32 is a Protobuf message, it's encoded as a
    // length delimited type. Setting Id to 1 will yield four bytes.
    // The first two indicate the type and length of the NullableInt32
    // message, and the last two indicate the type and value held within.
    r.Id = 1;
    r.ToByteArray(); // => byte[] {
                     //      0x0a, // field  = 1, type = 2 (length delimited)
                     //      0x02, // length = 2
                     //      0x08, // field  = 1, type = 0 (varint)
                     //      0x01, // value  = 1
                     //    }
    // When Id is set to the default int32 value of 0, only two bytes
    // are needed since default values are not sent over the wire.
    // These two bytes just indicate that an empty NullableInt32 exists.
    r.Id = 0;
    r.ToByteArray(); // => byte[] {
                     //      0x0a, // field  = 1, type = 2 (length delimited)
                     //      0x00, // length = 0
                     //    }
