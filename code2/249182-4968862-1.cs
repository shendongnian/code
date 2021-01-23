    public class B : A, ITypeFG
    {
        public TypeF FieldB { get; set; }
        A ITypeFG.FieldFG { get { return FieldB; } set { FieldB = (TypeF)value; } }
    }
    public class C : A, ITypeFG
    {
        public TypeG FieldC { get; set; }
        A ITypeFG.FieldFG { get { return FieldC; } set { FieldC = (TypeG)value; } }
    }
