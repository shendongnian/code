    public virtual string StatusString
    {
        get { return Status.ToString(); }
        set { OrderStatus newValue; 
              if (Enum.TryParse(value, out newValue))
              { Status = newValue; }
            }
    }
    public virtual OrderStatus Status { get; set; } 
