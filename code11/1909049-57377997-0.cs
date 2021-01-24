    private object GetClass(string nspace, string jobname)
    {
      StringBuilder sb = new StringBuilder();
      sb.Append(nspace).Append(".").Append(jobname);
      string strFullyQualifiedName = sb.ToString();
      Type type = Type.GetType(strFullyQualifiedName);
      if (type != null) return Activator.CreateInstance(type);
      foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
      {
        type = asm.GetType(strFullyQualifiedName);
        if (type != null)
          return Activator.CreateInstance(type);
      }
      return null;
    }
