    int myInt = 800;
    byte[] myByteArray = System.BitConverter.GetBytes(myInt);
    if (BitConverter.IsLittleEndian) {
        // get the first 3 elements
    } else {
        // get the last 3 elements
    }
