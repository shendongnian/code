    public static void GenericMethod<T0, T1>(T0 direct, IEnumerable<T1> generic)
         where T0 : struct
         where T1 : class, new(), IInterface
    { }
    public class CandidateA : IInterface { private CandidateA(); }
    public struct CandidateB : IInterface { }
    public class CandidateC { public CandidateC(); }
    public class CandidateD : IInterface { public CandidateD(); }
    var method = GetMethod("GenericMethod");
    var type0 = method.GetParameters()[0].ParameterType;
    var type1 = method.GetParameters()[1].ParameterType;
    // Testing:
    type0.IsAssignableFromGeneric(typeof(int)) // true
    type0.IsAssignableFromGeneric(typeof(IList)) // false, fails struct
    type1.IsAssignableFromGeneric(typeof(IEnumerable<CandidateA>)) // false, fails new()
    type1.IsAssignableFromGeneric(typeof(IEnumerable<CandidateB>)) // false, fails class
    type1.IsAssignableFromGeneric(typeof(IEnumerable<CandidateC>)) // false, fails : IInterface
    type1.IsAssignableFromGeneric(typeof(IEnumerable<CandidateD>)) // true
