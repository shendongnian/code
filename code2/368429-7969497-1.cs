    public object foo; 
    public void Create()
    {
      this.foo = new { Id = 1, Name = "Melvin" };
    }
    public void Consume()
    {
      var x = new { Id = 0, Name = String.Empty };
      var y = this.Cast(this.foo, x);
    }
    public T Cast<T> ( object o, T template )
    {
      return (T)o;
    }
