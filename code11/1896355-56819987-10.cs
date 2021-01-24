    this.ActionsList = new List<MyAction> {
       new MyAction { Order = 1, Text = "Method 5", Action = o => o.Method5(), IsActive = true },
       new MyAction { Order = 5, Text = "Method 1", Action = o => o.Method1(), IsActive = false },
       new MyAction { Order = 3, Text = "Method 3", Action = o => o.Method3(), IsActive = true }
    };
