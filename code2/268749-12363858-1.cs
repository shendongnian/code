    public class Exhibit
    {
        public virtual Document Document { get; set; }
        public virtual ExhibitType ExhibitType { get; set; }
        #region System.Object
        public override bool Equals(object obj)
        {
            return Equals(obj as Exhibit);
        }
        public bool Equals(Exhibit other)
        {
            return other != null &&
                Document.Equals(other.Document) &&
                ExhibitType.Equals(other.ExhibitType);
        }
        public override int GetHashCode()
        {
            return this.CalculateHashCode(
                () => Document, 
                () => ExhibitType);
        }
        #endregion
    }
