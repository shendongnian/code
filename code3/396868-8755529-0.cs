    [PersistChildren(false), TypeConverter(typeof(ExpandableObjectConverter)), ParseChildren(true), Serializable()]
        public class ControlDependencySetting
        {
            [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content),
                PersistenceMode(PersistenceMode.InnerProperty)]
            public List<ControlDependency> ControlDependencies { get; set; }
    
            ***Code emitted
        }
    [PersistChildren(false), TypeConverter(typeof(ExpandableObjectConverter)), ParseChildren(true),Serializable()]
        public class ControlDependency
        {
            [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content), 
                PersistenceMode(PersistenceMode.InnerProperty)]
            public List<ControlDependency> ControlDependencies { get; set; }
    
           **Code Emitted
            
        }
