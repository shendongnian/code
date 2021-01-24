    public virtual void WriteLine(Object value) {
       if (value==null) {
          WriteLine();
       }
       else {
          // Call WriteLine(value.ToString), not Write(Object), WriteLine().
          // This makes calls to WriteLine(Object) atomic.
          IFormattable f = value as IFormattable;
          if (f != null)
             WriteLine(f.ToString(null, FormatProvider));
          else
             WriteLine(value.ToString());
       }
    }
