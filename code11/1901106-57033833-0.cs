    public class SampleInner
    {
		[JsonProperty] // Adding this attribute informs Json.NET that the private setter can be called.
        public string AnotherText { get; private set; }
		[JsonProperty]
        public int AnotherNumber { get; private set; }
		[JsonConstructor] // Adding this attribute informs Json.NET that this private constructor can be called
		private SampleInner() { }
		
        public SampleInner(string anotherText, int anotherNumber)
        {
            this.AnotherText = anotherText;
            this.AnotherNumber = anotherNumber;
        }		
    }
