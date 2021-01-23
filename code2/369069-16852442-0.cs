    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    [Serializable]
    public class Entity
    {
        public int EntityID { get; set; }
        public string EntityName { get; set; }
        [JsonIgnore]
        public virtual Parent Parent { get; set; }
        [JsonIgnore]
        public virtual List<Child> Children { get; set; }
    }
