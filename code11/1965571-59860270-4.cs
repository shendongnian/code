    public class ComponentB : Component
    {
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [ReadOnly(true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DisplayName("(Events)")]
        public event EventHandler Dummy { add { } remove { } }
        // ... rest of properties ...
     }
