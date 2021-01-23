    protected override OnPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
        if(e.Property == ProblemProperty)
        {
            Arithmetic p = (Arithmetic)Problem;
            Number1 = p.Number1;
            Number2 = p.Number2;
            Operator = p.Operation;
        }
    }
