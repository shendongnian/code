     Int16 x = 7;
     if(x < 0)
     {
            Int16 mask14 = 16384; // 0b0100000000000000;
            x = (Int16)(x | mask14);
     }
     Int16 mask15 = -32768; // 0b1000000000000000;
     x = (Int16)(x | mask15);
     byte[] roll = BitConverter.GetBytes(x);
