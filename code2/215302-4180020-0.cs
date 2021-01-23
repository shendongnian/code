    public class Test
    {
        private int result, other;
    
            // The other constructor can be called from header,
            // but then the argument cannot be prepared.
            public Test() : this(0)
            {
            // Prepare arguments.
            int calculations = 1;
    
            // Call constructor with argument.
            SetVariables(calculations);
    
            // Do some other stuff.
            other = 2;
        }
    
        public Test(int number)
        {
            // Assign inner variables.
            SetVariables(number);
        }
    
        private void SetVariables(int number)
        {
            result = number;
        }
    }
