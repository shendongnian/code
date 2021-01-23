    ArrayList x=new ArrayList();
    x.Add(10);
    x.Add("SS");
    IEnumerator enumerator = (x).GetEnumerator();
    try {
       while (enumerator.MoveNext()) {
          string element = (string)enumerator.Current; // here is casting occures
          // loop body;
       }
    }
    finally {
       IDisposable disposable = enumerator as System.IDisposable;
       if (disposable != null) disposable.Dispose();
    }
