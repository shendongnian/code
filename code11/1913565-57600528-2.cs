    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
            }
            static byte[] Script(byte[] byteTag)
            {
                uint tag =  (byte[0] << 24) | (byte[1] << 16) | (byte[2] << 8) | byte[3];
                uint maxNumericTag = 0x0000FFFF;
                int minOldSchemeHighByteValue = 36;// 36th characters in symbolSpace
                byte[] results = new byte[4];
                if (tag <= maxNumericTag)
                {
                    results = byteTag;
                }
                else
                {
                    if (minOldSchemeHighByteValue <= (tag >> 24))
                    {
                        results = byteTag; //script is just converting an int to a byte[]
                    }
                    else
                    {
                       results[0] = (byte)((((tag >> 24) & 0x3F) - 26) + (byte)'0');
                       results[1] = (byte)((((tag >> 18) & 0x3F) - 26) + (byte)'0');
                       results[2] = (byte)((((tag >> 12) & 0x3F) - 26) + (byte)'0');
                       results[3] = (byte)(((tag & 0x3F) - 26) + (byte)'0');
                    }
                }
                return results;
            }
        }
    }
