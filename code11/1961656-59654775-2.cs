    class Program
    {
        static void Main(string[] args)
        {
            Scope scope = new Scope();
            String works = scope.canBeAccessedOutside;
            String wontWork = scope.cannotBeAccessedOutside; // Compile error.
            String stillWontWork = scope.cannotBeAccessedOutsideThisMethod; // Compile error.
            scope.MethodCanBeAccessedOutside();
            scope.MethodCannotBeAccessedOutside(); // Compile error.
        }
    }
    class Scope
    {
        // Since it is declared inside the class scope, you can use it anywhere in the class, and outside since it is public.
        public String canBeAccessedOutside;
        // Since it is declared inside the class scope, you can use it anywhere in the class, but not outside since it is private.
        private String cannotBeAccessedOutside; 
        // Can be used inside and outside the class.
        public void MethodCanBeAccessedOutside()
        {
            // Can only be used inside this method.
            String cannotBeAccessedOutsideThisMethod;
            MethodCannotBeAccessedOutside(); // Compile since this is in the same class.
        }
        // Can only be used inside this class.
        private void MethodCannotBeAccessedOutside()
        {
            String doesntWork = cannotBeAccessedOutsideThisMethod; // Compile error. 
            String work = cannotBeAccessedOutside;
        }
    }
