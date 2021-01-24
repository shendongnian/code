      public double? this[int index]
      {
        get
        {
          CheckIndex(index, 1, vars.Length + 1);
          return vars[index + 1];
        }
        set
        {
          CheckIndex(index, 1, vars.Length + 1);
          vars[index + 1] = value;
        }
      }
    }
