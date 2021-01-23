    public class Tractor : IEquipment
    {
        public bool IsPMRequired()
        {
            //Implement logic here specific to a Tractor
            throw new NotImplementedException();
        }
        public RecurrenceType RecurrenceType
        {
            get { throw new NotImplementedException(); }
        }
        public RecurrenceFrequency RecurrenceFrequency
        {
            get { throw new NotImplementedException(); }
        }
        public object RecurrenceValue
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
