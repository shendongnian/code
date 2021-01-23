     public static IEnumerable<TBase> Cast(IEnumerable<TDerived> source)
         where TDerived : TBase
     {
         foreach (TDerived item in source)
         {
             yield return item;
         }
     }
