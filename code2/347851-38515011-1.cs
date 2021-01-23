    using System.Collections;
    using System.Data.Objects.DataClasses;
     
    namespace TimestampComparers
    {
        public static class TimestampComparers
        {
     
            [EdmFunction("TimestampComparers", "IsLessThan")]
            public static bool IsLessThan(this byte[] source, byte[] target)
            {
                return StructuralComparisons.StructuralComparer.Compare(source, target) == -1;
            }
     
            [EdmFunction("TimestampComparers", "IsGreaterThan")]
            public static bool IsGreaterThan(this byte[] source, byte[] target)
            {
                return StructuralComparisons.StructuralComparer.Compare(source, target) == 1;
            }
     
            [EdmFunction("TimestampComparers", "IsLessThanOrEqualTo")]
            public static bool IsLessThanOrEqualTo(this byte[] source, byte[] target)
            {
                return StructuralComparisons.StructuralComparer.Compare(source, target) < 1;
            }
     
            [EdmFunction("TimestampComparers", "IsGreaterThanOrEqualTo")]
            public static bool IsGreaterThanOrEqualTo(this byte[] source, byte[] target)
            {
                return StructuralComparisons.StructuralComparer.Compare(source, target) > -1;
            }
        }
    }
