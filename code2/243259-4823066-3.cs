    using Algebra;
    namespace NotAlgebra
    {
        public class XYZ
        {
            // Refers to NotAlgebra.Vector3 (defined in File 1 above)
            Vector3 MyProperty1 { get; }
    
            // Refers to Algebra.Vector3 (defined in the external library)
            Algebra.Vector3 MyProperty2 { get; }
        }
    }
