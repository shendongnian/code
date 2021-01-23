        private static byte[] ConvertUInt32ArrayToByteArray(uint[] value)
        {
            const int bytesPerUInt32 = 4;
            byte[] result = new byte[value.Length * bytesPerUInt32];
            for (int index = 0; index < value.Length; index++)
            {
                byte[] partialResult = System.BitConverter.GetBytes(value[index]);
                for (int indexTwo = 0; indexTwo < partialResult.Length; indexTwo++)
                    result[index * bytesPerUInt32 + indexTwo] = partialResult[indexTwo];
            }
            return result;
        }
