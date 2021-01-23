        public int MinimumValue { get; private set; }
        public int MaxmimumValue { get; private set; }
        public void num()
        {
            int[] array = { 12, 56, 89, 65, 61, 36, 45, 23 };
            MaxmimumValue = array[0];
            MinimumValue = array[0];
            foreach (int num in array)
            {
                if (num > MaxmimumValue) MaxmimumValue = num;
                if (num < MinimumValue) MinimumValue = num;
            }
        }
