        /// <summary>
        /// Gens the CRC16.
        /// CRC-1021 = X(16)+x(12)+x(5)+1
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="nByte">The n byte.</param>
        /// <returns>System.Byte[][].</returns>
        public ushort GenCrc16(byte[] c, int nByte)
        {
            ushort Polynominal = 0x1021;
            ushort InitValue = 0x0;
            ushort i, j, index = 0;
            ushort CRC = InitValue;
            ushort Remainder, tmp, short_c;
            for (i = 0; i < nByte; i++)
            {
                short_c = (ushort)(0x00ff & (ushort) c[index]);
                tmp = (ushort)((CRC >> 8) ^ short_c);
                Remainder = (ushort)(tmp << 8);
                for (j = 0; j < 8; j++)
                {
                    if ((Remainder & 0x8000) != 0)
                    {
                        Remainder = (ushort)((Remainder << 1) ^ Polynominal);
                    }
                    else
                    {
                        Remainder = (ushort)(Remainder << 1);
                    }
                }
                CRC = (ushort)((CRC << 8) ^ Remainder);
                index++;
            }
            return CRC;
        }
