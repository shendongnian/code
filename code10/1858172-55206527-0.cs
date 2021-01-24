    TwoDPoint? a = new TwoDPoint();
    var b = (TwoDPoint)a;
    // call Nullable<TwoDPoint>.Equals, not TwoDPoint.Equals
    a.Equals(b);
    // call TwoDPoint.Equals
    b.Equals(b);
