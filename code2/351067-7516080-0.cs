    System.Reflection.PropertyInfo aProp =
            typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance);
     aProp.SetValue(YourControlNameHere, true, null);
