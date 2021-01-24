    private static byte[] Nibbles(IEnumerable<string> data) {
      List<byte> list = new List<byte>();
      bool head = true;
      foreach (var item in data) {
        byte value = item.StartsWith("0x", StringComparison.OrdinalIgnoreCase) 
          ? Convert.ToByte(item, 16)
          : Convert.ToByte(item, 10);
        // Do we have a nibble? 
        // 0xDigit (Length = 3) or Digit (Length = 1) are supposed to be nibble
        if (item.Length == 3 || item.Length == 1) { // Nibble
          if (head)                                 // Head
            list.Add(Convert.ToByte(item, 16));
          else                                      // Tail
            list[list.Count - 1] = (byte)(list[list.Count - 1] * 16 + value);
          head = !head;
        }
        else { // Entire byte
          head = true;
          list.Add(value);
        }
      }
      return list.ToArray();
    }
    ...
    string[] content = { "0x1", "5", "0x8", "7", "0x66" };
    Console.Write(string.Join(", ", Nibbles(content)
      .Select(item => $"0x{item:x2}").ToArray()));
