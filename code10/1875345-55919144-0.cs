   public class Foo
   {
      private float propA = 1.0f;
      public float PropA
      {
         get => propA;
         set => CheckAndExecute(ref propA, value);
      }
      private int propB = 2;
      public int PropB
      {
         get => propB;
         set => CheckAndExecute(ref propB, value);
      }
      private double propC = -1.0;
      public double PropC
      {
         get => propC;
         set => CheckAndExecute(ref propC, value);
      }
      private void CheckAndExecute<T>(ref T oldVal, T newVal) where T : IEquatable<T>
      {
         if (((IEquatable<T>) oldVal).Equals(newVal)) return;
         oldVal = newVal;
         DoBar();
      }
      void DoBar()
      {
         //...Something is going on here
      }
You do the repeated work in a generic.
