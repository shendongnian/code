            // generate 8 byte random value
            Random rnd = new Random();
            byte[] bytes = new byte[8];
            rnd.NextBytes(bytes);
            // displaying the value
            string myRndID = BitConverter.ToString(bytes).Replace("-", "");
            Console.WriteLine(myRndID);
