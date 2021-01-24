    class Program
    {
        static void Main(string[] args) // START PARENT SCOPE
        {
            for( // START CHILD SCOPE
                int i = 0; // This will throw exception because i already exists in the parent scope
                i < 10; 
                i++
                )
            {
                //DO THINGS...
            } // END CHILD SCOPE
            int i = 10;
        } // END PARENT SCOPE
    }
