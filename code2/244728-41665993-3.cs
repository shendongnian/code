    public static void GenericMethod<T0, T1>(T0 direct, IEnumerable<T1> generic)
         where T0 : struct
         where T1 : class, new(), IInterface
    { }
    public interface IInterface { }
    public class CandidateA : IInterface { private CandidateA(); }
    public struct CandidateB : IInterface { }
    public class CandidateC { public CandidateC(); }
    public class CandidateD : IInterface { public CandidateD(); }
    var method = GetMethod("GenericMethod");
    var type0 = method.GetParameters()[0].ParameterType;
    var type1 = method.GetParameters()[1].ParameterType;
    // Results:
    type0.CanMakeGenericTypeVia(typeof(int)) // true
    type0.CanMakeGenericTypeVia(typeof(IList)) // false, fails struct
    type1.CanMakeGenericTypeVia(typeof(IEnumerable<CandidateA>)) 
    // false, fails new()
    type1.CanMakeGenericTypeVia(typeof(IEnumerable<CandidateB>)) 
    // false, fails class
    type1.CanMakeGenericTypeVia(typeof(IEnumerable<CandidateC>)) 
    // false, fails : IInterface
    type1.CanMakeGenericTypeVia(typeof(IEnumerable<CandidateD>)) 
    // true
    type0.MakeGenericTypeVia(typeof(int)) 
    // typeof(int)
    type1.MakeGenericTypeVia(typeof(List<CandidateD>)) 
    // IEnumerable<CandidateD>
    method.MakeGenericMethodVia(123.GetType(), (new CandidateD[0]).GetType()) 
    // GenericMethod(int, IEnumerable<CandidateD>)
    method.MakeGenericMethodVia(123.GetType(), type1)
    // GenericMethod<T1>(int, IEnumerable<T1>)
    // (partial resolution)
