    using (FileStream vStream = File.Create(pfilePath))
    {
        // Creates the UTF-8 encoding with parameter "encoderShouldEmitUTF8Identifier" set to true
        Encoding vUTF8Encoding = new UTF8Encoding(true);
        // Gets the preamble in order to attach the BOM
        var vPreambleByte = vUTF8Encoding.GetPreamble();
        // Writes the preamble first
    	vStream.Write(vPreambleByte, 0, vPreambleByte.Length);
        // Gets the bytes from text
        byte[] vByteData = vUTF8Encoding.GetBytes(pTextToSaveToFile);
        vStream.Write(vByteData, 0, vByteData.Length);
        vStream.Close();
    }
