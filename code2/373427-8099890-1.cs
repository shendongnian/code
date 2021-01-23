    var attributes = typeof(A).GetCustomAttributes(A.GetDerivedFromAOnlyAttributeType(), false);
    // using an attribute outside the A class
    class A {
        protected class DerivedFromAOnlyAttribute : Attribute { }
        public static Type GetDerivedFromAOnlyAttributeType() {
            return typeof(DerivedFromAOnlyAttribute);
        }
    }
    [A.DerivedFromAOnly] //ok
    class B : A {
    }
    [A.DerivedFromAOnly] //error
    class C { 
    }
