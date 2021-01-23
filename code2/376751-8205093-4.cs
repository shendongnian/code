    internal sealed class MyBinder : SerializationBinder
    {
     public override Type BindToType(string assemblyName, string typeName)
     {
      Type ttd = null;
      try
      {
       string toassname = assemblyName.Split(',')[0];
       Assembly[] asmblies = AppDomain.CurrentDomain.GetAssemblies();
       foreach (Assembly ass in asmblies)
       {
        if (ass.FullName.Split(',')[0] == toassname)
        {
         ttd = ass.GetType(typeName);
         break;
        }
       }
      }
      catch (System.Exception e)
      {
       Debug.WriteLine(e.Message);
      }
      return ttd;
     }
    }
