    public static void DisposeIfPossible(this Pen pen)
    {
        var field = pen.GetType().GetField("immutable", BindingFlags.Instance|BindingFlags.NonPublic);
        if ((bool)field.GetValue(pen) == false)
            pen.Dispose();
    }
