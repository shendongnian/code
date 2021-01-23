    [DataContract]
    public class Fraction
    {
        [DataMember(Name = "Frac")]
        private string serialized;
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }
        [OnSerializing]
        public void OnSerializing(StreamingContext context)
        {
            // This gets called just before the DataContractSerializer begins.
            serialized = Numerator.ToString() + "/" + Denominator.ToString();
        }
        [OnDeserialized]
        public void OnDeserialized(StreamingContext context)
        {
            // This gets called after the DataContractSerializer finishes its work
            var nums = serialized.Split("/");
            Numerator = int.Parse(nums[0]);
            Denominator = int.Parse(nums[1]);
        }
    }
