    // You want to store in same table and not a navigation property, right?
    // Then you need [ComplexType]
    [ComplexType] 
    public class PhoneNumber : IEquatable<PhoneNumber>, IComparable<PhoneNumber>
    {
        // ...
        public string FullNumber
        {
            get
            {
                return Prefix + "-" + AreaCode + " " + Number; // or whatever
            }
            set
            {
                AreaCode = ParseToAreaCode(value); // or so...
                Prefix = ParseToPrefix(value);     // or so...
                Number = ParseToNumber(value);     // or so...
            }
        }
        [NotMapped]
        public string AreaCode { get; set; }
        [NotMapped]
        public string Prefix { get; set; }
        [NotMapped]
        public string Number { get; set; }
    }
