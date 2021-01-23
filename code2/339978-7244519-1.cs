    public static int GetHashCode(byte[] array) {
        unchecked {
            int i = 0;
            int hash = 17;
            int rounded = array.Length & ~3;
            hash = 31 * hash + array.Length;
            for (; i < rounded; i += 4) {
                hash = 31 * hash + BitConverter.ToInt32(array, i);
            }
            if (i < array.Length) {
                int val = array[i];
                i++;
                if (i < array.Length) {
                    val |= array[i] << 8;
                    i++;
                    if (i < array.Length) {
                        val |= array[i] << 16;
                    }
                }
                hash = 31 * hash + val;
            }
            return hash;
        }
    }
