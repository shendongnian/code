    public class equip
      {
       [DisplayName("Equipment ID")]
       public int EquipID {get;set;}
       [DisplayName("Equipment Name")]
       public string EquipName {get;set;}
       [Browsable(false)]
       public int recordId {get; private set;}
      }
