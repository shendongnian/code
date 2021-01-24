    public class OrderMaker<O, P, T>
        where O : class, IOrderMaker
        where T : class, O, new()
        where P : IService
    {
        public static O CreateInstance(P p) { //<--
            O objO;
    
            objO = new T();
    
            objO.SetPatient(p); //<---
    
            return objO;
        }
    }
