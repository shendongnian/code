        public double? GetVolume(object data)
        {
            double value;
            if (data != null && double.TryParse(data.ToString(), out value))
                return value;
            return null;
        }
        public void Assign(DataRow theRowInput, DataRow theRowOutput)
        {
            theRowOutput[0] = (object)GetVolume(theRowInput[0]) ?? DBNull.Value;
        }
