    class HierarchyBaseInheritorB : HierarchyBaseInheritorA<HierarchyBaseInheritorB>
    {
        public HierarchyBaseInheritorB()
        {
            validators.Add(x => x.A < 20);
            validators.Add(x => x.B > 0);
            validators.Add(x => x.C == 0);
        }
        public int C { get; set; }
    }
