            // BLAKE2b
            // using System.Data.HashFunction;
            //
            // String message to use.
            string str = "The quick brown fox jumps over the lazy dog";
            // Initialize
            System.Data.HashFunction.Blake2B Blake2B = new System.Data.HashFunction.Blake2B();
            // Get string hash bytes; create 64 bit hash.
            var HashBytes = Blake2B.ComputeHash(str, 64);
            // Convert bytes to string and remove the dashes.
            string hexString = BitConverter.ToString(HashBytes).Replace("-", string.Empty);
            // Display results.
            MessageBox.Show(hexString);
            /*
             * "The quick brown fox jumps over the lazy dog" produces a hash value of
             * "A8ADD4BDDDFD93E4877D2746E62817B116364A1FA7BC148D95090BC7333B3673F82401CF7AA2E4CB1ECD90296E3F14CB5413F8ED77BE73045B13914CDCD6A918"
             * and "2FD0F3FB3BD58455" hash for 64 bits.
             */
