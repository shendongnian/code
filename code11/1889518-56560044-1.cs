    rijAlg.Key = StringToByteArray("519C7C3402A943D8AF83746C1548E475319EBDA6A38046059F83B21709BD6A5B"); //32 bytes
    rijAlg.IV =  StringToByteArray("0D024CF947CE4C288880D0B34D29BFA5"); // 16 bytes
	...
    swEncrypt.Write(originalMsg);
    swEncrypt.Flush();
    swEncrypt.Close();
    ...
    Console.WriteLine("encrypted bytes: '" + ByteArrayToString(encryptedMsg) + "'");
	
