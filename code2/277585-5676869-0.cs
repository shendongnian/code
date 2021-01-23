    public static class MyExtensions{
      public static bool IsVowel( this char c ){
        return new[]{ 'a','e','i','o','u','y','A','E','I','O','U','Y' }.Contains(c);
      }
    }
