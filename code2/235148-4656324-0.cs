    public class ListItem : IComparable<ListItem>
    {
        public int RollNumber { get; set; }
        public string Name { get; set; }
        public string AdmissionCode { get; set; }
        #region Implementation of IComparable<in ListItem>
        public int CompareTo(ListItem other)
        {
            return this.AdmissionCode.Length != other.AdmissionCode.Length
                ? this.AdmissionCode.Length.CompareTo(other.AdmissionCode.Length)
                : this.AdmissionCode.CompareTo(other.AdmissionCode);
        }
        #endregion
    }
