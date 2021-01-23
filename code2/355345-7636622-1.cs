    class SomeClass
    {
        // whatever shared state of the class     
        // whatever methods of the class     
        public void MethodThatIsntDoingTooMuch()
        {
            bigSomethingDoer.Do();
        }
    }
    class BigSomethingDoer
    {
        // shared locals are fields instead
        public void Do() 
        {
            // refactor long method into smaller methods
            // shared locals are promoted to class fields
            // this smaller class only does this one thing
            // --> its state does not pollute another class
        }
    }
