    public void Doit() {
      var data=LoadAssemblyFromParamenter(pathToDataDll);
      var mi=this.GetType().GetMethod("SomeTest").MakeGenericMethod(data.GetType());
      mi.Invoke(this, new object[0]);
    }
    public void SomeTest<T>() {
      Debug.WriteLine("typeof(T) is "+typeof(T));
    }
