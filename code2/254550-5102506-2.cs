    private int value=0;
    private int a, b;
    public int A
    {
       set
       {
          this.a = value;
          Value++;
       }
       get { return this.a; }
    }
    public int B
    {
       set
       {
          this.b = value;
          Value++;
       }
       get { return this.b; }
    }
    private int Value
    {
       set
       {
          this.value = value;
          if (this.value > 10)
          {
             // Exit.
          }
       }
       get { return this.value; }
    }
