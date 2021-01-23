    //only for forbiding the calls of constructors without parameters on derived classes
    public class UnconstructableWithoutArguments
    {
        private UnconstructableWithoutArguments()
        {
        }
        public UnconstructableWithoutArguments(params object[] list)
        {
        }
    }
