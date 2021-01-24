 private int GridWidth;
 private int GridHeight;
Above was supposed to be
  private int gridWidth;
  private int gridHeight;
This is because you already have a public readonly property with the same name, which internally refers to the private variables.
Now, for change the variable, you need to use
var WorldField = typeof(World).GetField("gridWidth", BindingFlags.Instance | BindingFlags.NonPublic);
WorldField.SetValue(World.inst, 100);
Please note the flags has been changed to `BindingFlags.Instance | BindingFlags.NonPublic`. This is because, the variable concerned 'gridWidth' is a `private` variable and hence need to use `BindingGlags.NonPublic` Flag.
In the code given in OP, you were incorrectly attempting to set the readonly public properties. Instead, you need to target the private variables.
   
