    int myInt = 800;
    byte[] myByteArray = System.BitConverter.GetBytes(myInt);
    if (BitConverter.IsLittleEndian) {
        // get the last 3 elements
    } else {
        // get the first 3 elements
    }
