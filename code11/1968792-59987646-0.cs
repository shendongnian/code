    class ArrayModel
    {
        private readonly bool[] status;
        public ArrayModel(int lightCount)
        {
            status = new bool[lightCount];
        }
        public void Update(bool headLightStatus)
        {
            // update each cell of the array with the value of previous cell
            // we iterate in reverse order, otherwise it fills the buffer with the first value
            for (var i = status.Length - 1; i >= 1; i--)
                status[i] = status[i - 1];
            // set head light status
            status[0] = headLightStatus
        }
    }
