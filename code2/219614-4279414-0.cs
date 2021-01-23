    int[] badMatch = new int[256];
    byte[] pattern;  //the pattern we are searching for
    
    //badMath is an array of every possible byte value (defined as static later).
    //we use this as a jump table to know how many characters we can skip comparison on
    //so first, we prefill every possibility with the length of our search string
    for (int i = 0; i < badMatch.Length; i++)
    {
      badMatch[i] = pattern.Length;
    }
    
    //Now we need to calculate the individual maximum jump length for each byte that appears in my search string
    for (int i = 0; i < pattern.Length - 1; i++)
    {
      badMatch[pattern[i] & 0xff] = pattern.Length - i - 1;
    }
    
    // Place the bytes you want to run the search against in the payload variable
    byte[] payload = <bytes>
    
    // search the packet starting at offset, and try to match the last character
    // if we loop, we increment by whatever our jump value is
    for (i = offset + pattern.Length - 1; i < end && cont; i += badMatch[payload[i] & 0xff])
    {
      // if our payload character equals our search string character, continue matching counting backwards
      for (j = pattern.Length - 1, k = i; (j >= 0) && (payload[k] == pattern[j]) && cont; j--)
      {
        k--;
      }
    // if we matched every character, then we have a match, add it to the packet list, and exit the search (cont = false)
      if (j == -1)
      {
        //we MATCHED!!!
        //i = end;
        cont = false;
      }
    }
