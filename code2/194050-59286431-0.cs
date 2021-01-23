            string binaryString = "011100100111001001110011";
            int G = 0;
            for (int i = 0; i < binaryString.Length; i++)
                G += (int)((binaryString[binaryString.Length - (i + 1)] & 1) << (i % 32));
            Console.WriteLine(G); //‭7500403‬
            binaryString = string.Empty;
            
            for (int i = 31; i >= 0; i--)
            {
                binaryString += (char)(((G & (1 << (i % 32))) >> (i % 32)) | 48);
            }
            Console.WriteLine(binaryString); //00000000011100100111001001110011
