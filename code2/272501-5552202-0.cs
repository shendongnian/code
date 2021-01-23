    using System.ComponentModel;
    List<equip> EquipList = new List<equip>();
  
    DataGridView.Datasource = EquipList;
   
    public class equip
      {
       [DisplayName("Equipment ID")]
       public int EquipID {get;set;}
       [DisplayName("Equipment Name")]
       public string EquipName {get;set;}
      }
