    long longValue = 9999999999L;
            Console.WriteLine("Long value: " + longValue.ToString());
            bytes = BitConverter.GetBytes(longValue);
            Console.WriteLine("Byte array value:");
            Console.WriteLine(BitConverter.ToString(bytes));
           
