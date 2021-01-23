    public static class Program {
        public static void Main() {
            Expression<Func<DummyClass, Boolean>> predicate = WageConstIn => WageConstIn.Serialno.ToString().StartsWith("2800");
        }
    }
