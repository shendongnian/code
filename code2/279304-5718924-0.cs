        BinaryWriter guessesWriter = new BinaryWriter(new StreamWriter("guesses.dat"));
        private void QueueStart()
        {
            while (true)
            {             
                if (writeQueue.Count > 0)
                {
                    lock (guessesWriter)
                    {
                        guessesWriter.Write(writeQueue[0]);
                    }
                    writeQueue.Remove(writeQueue[0]);
                }
            }
        }
        private const int numbersPerThread = 6;
        private static void Check()
        {
            BinaryReader tr = new BinaryReader(new StreamReader("data.txt"));
            b = 0;
            List<Thread> threads = new List<Thread>();
            while (tr.BaseStream.Position < tr.BaseStream.Length)
            {
                List<int> numbers = new List<int>(numbersPerThread);
                for (int index = 0; index < numbersPerThread; index++)
                {
                    numbers.Add(tr.ReadInt32());
                }
                threads.Add(new Thread(GuessCheck));
                threads[b].Start(numbers);
                b++;
            }
        }
