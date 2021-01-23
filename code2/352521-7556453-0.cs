    public void Doit() {
      dynamic data=LoadAssemblyFromParamenter(pathToDataDll);
      SomeTest(data);
    }
    public void SomeTest<T>(T arg) {
      Debug.WriteLine("typeof(T) is "+typeof(T));
    }
