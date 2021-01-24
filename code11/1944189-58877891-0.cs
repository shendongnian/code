            static readonly int MAX_UNSIGNED_14_BIT = 16383;// 2^14-1
    
            public static byte[] EncodeSigned14Bit(short x)
            {
                var absoluteX = Math.Abs(x);
                if (absoluteX > MAX_UNSIGNED_14_BIT) throw new ArgumentException($"{nameof(x)} is too large and cannot be represented");
    
                byte[] roll = BitConverter.GetBytes(absoluteX);
    
                if (x < 0)
                {
                    roll[1] |= 0b01000000; //x is negative, set 14th bit 
                }
    
                roll[1] |= 0b10000000; // 15th bit is always set
                
                return roll;
            }
            static void Main(string[] args)
            {
                // testing some values
                var r1 = EncodeSigned14Bit(16383); // r1[0] = 255, r1[1] = 191
                var r2 = EncodeSigned14Bit(-16383); // r2[0] = 255, r2[1] = 255
            }
