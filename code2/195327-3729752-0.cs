    interface IMy
    {
        void OhMy();
    }
    class Explicit : IMy
    {
        public void IMy.OhMy() { }
    }
    class Implicit : IMy
    {
        public void OhMy() { }
    }
