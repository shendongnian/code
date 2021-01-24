    var byteData = File.ReadAllBytes(inputFileName);
    var bitData = new BitArray();
    
    for(var i = 0; i < bitData.Length; i++)
    {
        // do something to bitData[i] as bool values(true as 1 and false as 0);
    }
    bitData.CopyTo(byteData, 0);
    File.WriteAllBytes(outputFileName, byteData);
