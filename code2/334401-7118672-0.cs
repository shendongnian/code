    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace MBUS_Parse_Test.MDL64_Communication
    {
        /// <summary>
        /// Extracts MBUS telegramms
        /// </summary>
        class GetMBUS_Telegramms
        {
        #region Eigenschaften
        private static List<MbusTelegram> telegrams = new List<MbusTelegram>();
        #endregion
        public static List<MbusTelegram> GetTelegramms(byte[] logfile)
        {
            int startOfTele = ExtractFirstMBUSTelegramm(logfile);
            while (startOfTele != 0)
            {
                byte[] NewLogFile = new byte[logfile.Length - startOfTele];
                Buffer.BlockCopy(logfile, startOfTele, NewLogFile, 0, NewLogFile.Length);
                startOfTele = ExtractFirstMBUSTelegramm(NewLogFile);
                logfile = NewLogFile;
            }
            return telegrams;
        }
        private static int ExtractFirstMBUSTelegramm(byte[] logfile)
        {
            byte mbus_start = 0x68;
            int Start = Array.IndexOf(logfile, mbus_start);
            int offset = 10;
            if (logfile[Start + 3] == mbus_start)
            {
                byte[] newMBUS = new byte[logfile[Start + 1] + offset];
                Buffer.BlockCopy(logfile, Start, newMBUS, 0, logfile[Start + 1] + offset);
                MbusTelegram nuMBUS = new MbusTelegram(newMBUS);
                telegrams.Add(nuMBUS);
                return (Start + logfile[Start + 1] + offset);
            }
            return 0;
        }
        private System.Array ResizeArray(System.Array oldArray, int newSize)
        {
            int oldSize = oldArray.Length;
            System.Type elementType = oldArray.GetType().GetElementType();
            System.Array newArray = System.Array.CreateInstance(elementType, newSize);
            int preserveLength = System.Math.Min(oldSize, newSize);
            if (preserveLength > 0)
                System.Array.Copy(oldArray, newArray, preserveLength);
            return newArray;
        }
      }
    }
