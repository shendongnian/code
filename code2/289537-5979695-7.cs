    class Foo // Class and member names must be distinct
    {
        public delegate void ADelegate();
        public event ADelegate A;
        private void OnA()
        {
            if(A != null)
                A();
        }
        public void Func()
        {
            // Some code...
            OnA();
            // More code...
        }
    }
