    class HierarchyBaseInheritorB : HierarchyBaseInheritorA
    {
        public int C { get; set; }
        protected override bool OnValidate()
        {
            return base.OnValidate() && 
                   (this.A < 20) &&
                   (this.B > 0) &&
                   (this.C == 0);
        }
    }
