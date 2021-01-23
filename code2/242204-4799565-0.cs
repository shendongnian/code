    byte[] GetBlockOfData(string fileName, string blockName)
    {
        var allBytes = File.ReadAllBytes(fileName);
        // Assuming block names are ASCII-encoded
        var blockMarker = Encoding.ASCII.GetBytes(blockName + ":"); 
        // Scan for the first byte of the marker
        for (var i = 0; i < allBytes.Length; i++)
        {
            if (allBytes[i] == blockMarker[i])
            {
                // See if this is the entire marker
                var isMatch == true;
                for (var j = 0; j < blockMarker.Length; j++)
                {
                    if (allBytes[i + j] != blockMarker[j])
                    {
                        isMatch = false;
                        break;
                    }
                }
                if (isMatch)
                {
                    // Assuming it's a byte...
                    var blockLength = allBytes[i + blockMarker.Length];
                    var result = new byte[blockLength];
                    Array.Copy(
                        allBytes, i + blockMarker.Length + 1, result, 0,
                        blockLength);
                    return result;
                }
            }
        }
        return null;
    }
