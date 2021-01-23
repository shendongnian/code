    using System;
    // Assembly marked as compliant.
    [assembly: CLSCompliant(true)]
    // Class marked as compliant.
    [CLSCompliant(true)]
    public class MyCompliantClass {
       // ChangeValue exposes UInt32, which is not in CLS.
       // A compile-time warning results.
       public void ChangeValue(UInt32 value){ }
       public static void Main( ) {
       int i = 2;
       Console.WriteLine(i);
       }
    }
