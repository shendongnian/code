    void Bar<T>(T item)
      where T : UserControl, IMyInterface
    {
        item.Width = 120;    // user control property
        item.Foo();          // IMyInterface method
    }
