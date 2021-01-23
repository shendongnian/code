    class HierarchyBaseInheritorA<T> : HierarchyBase<T>
        where T : HierarchyBaseInheritorA<T>
    {
        public HierarchyBaseInheritorA()
        {
            validators.Add(x => x.A > 10);
            validators.Add(x => x.B != 0);
        }
        public int B { get; set; }
    }
