    namespace InventorySystem.Models
    {
        public class InventoryItem
        {
           public Int Id { get; set; }
           public string Notes { get; set; }
           ...
           public string NotesTruncated
           {
               get
               {
                   //you could add some additional code here to remove the <p>
                   return (Notes.Length > 50) ? Notes.Substring(0, 50) + "..." : Notes;
               }
           }
        }
    }
