    public class ComponentB : Component
    {
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [ReadOnly(true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DisplayName("Events")]
        [ParenthesizePropertyName(true)]
        public event EventHandler Dummy { add { } remove { } }
        // ... rest of properties ...
     }
