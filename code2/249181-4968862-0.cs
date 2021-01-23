    public class B : A, ITypeFG
    {
        public TypeF FieldB { get; set; } // please don't expose public fields...
        A ITypeFG.FieldFG { get { return FieldB; } }
    }
    public class C : A, ITypeFG
    {
        public TypeG FieldC { get; set; }
        A ITypeFG.FieldFG { get { return FieldC; } }
    }
