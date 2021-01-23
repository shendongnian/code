    string input = "aBc1$@[\\]^_{|{~";
    Encoding enc = new System.Text.ASCIIEncoding();
    byte[] b = enc.GetBytes(input);
    for (int i = input.Length - 1; i >= 0; i -= 1) {
       if ((b[i] & 0xdf) >= 65 && (b[i] & 0xdf) <= 90) { //check if alpha
          b[i] ^= 0x20; // then XOR the correct bit to change case
       }
    }
    Console.WriteLine(input);
    Console.WriteLine(enc.GetString(b));
