    class NonRepeatingRandom : Random
    {
        private HashSet<int> _usedValues = new HashSet<int>();
        public NonRepeatingRandom()
        {
        }
        public NonRepeatingRandom(int seed):base(seed)
        {
        }
        public override int Next(int minValue, int maxValue)
        {
            int rndVal = base.Next(minValue, maxValue);
            if (_usedValues.Contains(rndVal))
            {
                int oldRndVal = rndVal;
                do
                {
                    rndVal++;
                } while (_usedValues.Contains(rndVal) && rndVal <= maxValue);
                if (rndVal == maxValue + 1)
                {
                    rndVal = oldRndVal;
                    do
                    {
                        rndVal--;
                    } while (_usedValues.Contains(rndVal) && rndVal >= minValue);
                    if (rndVal == minValue - 1)
                    {
                        throw new ApplicationException("Cannot get non repeating random for provided range.");
                    }
                }
            }
            _usedValues.Add(rndVal);
            return rndVal;
        }
    }
