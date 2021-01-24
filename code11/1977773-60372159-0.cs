    class Verification
    {
      public static void VerifyAProperty(A source, A dest, string path = null)
      {
        path += "->A";
        VerifyBProperty(source.BProperty, dest.BProperty, path);
        VerifyDProperty(source.DProperty, dest.DProperty, path);
      }
      public static void VerifyBProperty(B source, B dest, string path = null)
      {
        path += "->B";
        VerifyDProperty(source.DProperty, dest.DProperty, path);
      }
      public static void VerifyDProperty(D source, D dest)
      {
        path += "->D";
        if (source.Value != dest.Value)
          Console.WriteLine($"Different values at: {path}");
      }
}
