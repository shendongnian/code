        private static readonly Dictionary<char, int> BITMASK_DICTIONARY = new Dictionary<char, int>
        {
            { ' ',  0b0000000000000000  },
            { 'D',  0b0001001000001111  },
        };
        private int ConvertCharToBitmask(char character)
        {
            // Check if char is available.
            if (BITMASK_DICTIONARY.Keys.Contains(character))
            {
                return BITMASK_DICTIONARY[character];
            }
            // If not, return default.
            return GetDefaultCharBitmask();
        }
        private int GetDefaultCharBitmask()
        {
            return BITMASK_DICTIONARY[DEFAULT_BITMASK_CHAR];
        }
        public void Show(string message)
        {
            // Ensure message has valid length.
            if(message.Length > NUMBER_OF_SEGMENTS)
            {
                throw new OperationCanceledException($"Maximum message length is {NUMBER_OF_SEGMENTS} characters.");
            }
            // Update buffer
            Logger.Log(this, $"Show for {message}");
            for (int i = 0; i < message.Length; i++)
            {
                var bitmask = ConvertCharToBitmask(message[i]);
                Logger.Log(this, $"Writing char: '{message[i]}' at index: {i}.");
                segmentBuffer[i * 2] = Convert.ToByte(bitmask & 0xFF);
                segmentBuffer[i * 2 + 1] = Convert.ToByte(bitmask >> 8 & 0xFF);
            }
            // Write buffer to device.
            ht16k33.Write(segmentBuffer);
        }
