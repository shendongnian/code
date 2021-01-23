    class ExtendedTextboxDesigner : ControlDesigner
    {
        public ExtendedTextboxDesigner()
        {
            var atts = (DesignerAttribute[])typeof(TextBox).GetCustomAttributes(
                typeof(DesignerAttribute),
                false);
    
            var designer = (ControlDesigner)Activator.CreateInstance(
                Type.GetType(atts[0].DesignerTypeName));
        }
    
        private ControlDesigner Base { get; set; }
    
        public override bool CanBeParentedTo(IDesigner parentDesigner)
        {
            return Base.CanBeParentedTo(parentDesigner);
        }
    
        // ...
    }
