    public void DoMyThing(IList<object> objects) {
      foreach (var obj in objects) {
        someOtherList.Add(new MyObj() {
          item1 = obj
        });
      }
    }
