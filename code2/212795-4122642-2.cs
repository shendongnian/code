        [Conditional("DEBUG")]
        public void CallMyMethod()
        {
            Console.WriteLine("This method will be called only when in DEBUG mode.");
            // notice the "DEBUG" string in the attribute parameter
        }
