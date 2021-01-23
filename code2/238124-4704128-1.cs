    class Program {
      void Do(List<DoubleOrDate> elm) {
        double[] X = new double[elm.Count];
        for(int i = 0; i < elm.Count; i++) {
          X[i] = elm[i].GetDouble();
        }
      }
    }
