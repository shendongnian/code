    var input = "0001020304050607";
    var bytes = input.ParseAsBytes();
    // bytes == new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 }
    var result = bytes.ToHexString();
    // result == "0001020304050607"
