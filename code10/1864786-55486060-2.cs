    [Serializable]
    public class OutputPerDay : List<List<Pricing>>
    {
        public OutputPerDay() : base()
        {
            for (int i = 0; i <= 31; i++)
            {
                this.Add(new List<Pricing>());
            }
        }
    }
