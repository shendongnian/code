    namespace DCS2000.IDCardExclude.UI.IdCardManagerServiceReference
    {
      [Serializable]
      [DataContract]
      public partial class IdCard : DomainObject
      {
        public override int GetHashCode()
        {
            return EffDte.GetHashCode();
        }
      }
    }
