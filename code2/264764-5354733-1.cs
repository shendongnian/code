    public static class Contracts {
      private sealed class ContractException : Exception { ... }
      public static void Requires(bool value) { 
        if (!value) {
          throw new ContractException(); 
        }
      }
    }
