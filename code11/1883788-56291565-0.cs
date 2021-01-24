    public void InitDrawItems(MyList<MyAbstractClass> items)
      foreach (var item in items) {
        Type type = o.GetType();
        // type is definitely NOT abstract, since the object was created, so it is a
        // non-abstract child class and I create the right "copy" of the item !
        MyAbstractClass newItem = Activator.CreateInstance(type) as MyAbstractClass;
        // ... do whatever I need with the item
      }
    }
