C#
        public bool SequenceHasDuplicateSymbols(char[] sequence) {
            char symbolToCheckFor;         
            for (int i = 0; i < sequence.Length; i++)
            {
                symbolToCheckFor = sequence[i];
                for (int j = 0; j < sequence.Length; j++)
                {
                    if (i != j)
                    {
                        if (symbolToCheckFor == sequence[j])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
