    public static class TaskExtensions
    {
        public static void RunTask<TA,TB>( Action<TA,TB> action, TA a, TB b )
        {
            Task newTask = new Task( () => action(a,b) );
            newTask.ContinueWith( MandatoryMethod );
            newTask.Start();
        }
        // if you need to support other signature (more parameters) you would need to
        // create additional overloads of RunTask with more generic parameters...
        public static void RunTask( Action action );
        public static void RunTask<TA>( Action<TA> action, TA a );
        // etc ...
        private static void MandatoryMethod( Task t ) { /* your continuation logic */ }
    }
