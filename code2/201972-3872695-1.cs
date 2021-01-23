    public object Convert(object[] values)
    {
       object[] copy = (object[]) values.Clone();
       return new DelegateCommand<object>(
                    delegate
                    {
                        foreach (ICommand cmd in copy)
                        {
                            cmd.Execute(null);
                        }
                    });
    }
