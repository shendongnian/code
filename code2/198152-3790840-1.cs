    class HierarchyBaseInheritorA : HierarchyBase
    {
        public int B { get; set; }
        protected override bool OnValidate()
        {
            return base.OnValidate() &&
                   (this.A > 10) &&
                   (this.B != 0);
        }
    }
