    protected override void OnValueChanged(double oldValue, double newValue)
    {
        QuadraticValue = a * Math.Pow(Value, 2) + b * Value + c;
        base.OnValueChanged(oldValue, newValue);
    }
    public double QuadraticValue
    {
        get {
            var qv = (double)GetValue(QuadraticValueProperty);
            if (double.IsNaN(qv))
                qv = 0;
            qv = Math.Max(qv, base.Minimum);
            qv = Math.Min(qv, base.Maximum);
            return qv;
        }
        set 
        {
            SetValue(QuadraticValueProperty, value);
        }
    }
