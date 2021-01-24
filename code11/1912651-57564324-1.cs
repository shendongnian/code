    [Serializable]
    public class CardDimensionRequirement : Dictionary<int, CardDimensionRequirementLine>
    {
        public CardDimensionRequirement() : base() { }
        protected CardDimensionRequirement(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Nothing to do since your class currently has no fields
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            // Deserialize fields here, if you ever add any.
        }
        // Remainder snipped
