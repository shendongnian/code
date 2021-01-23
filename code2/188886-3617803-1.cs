    public static class WorkflowExtensions
    {
        #region In
        public static InArgument<T> In<T>(this InArgument<T> self)
        {
            return new InArgument<T>(context => self.Get(context));
        }
        public static InArgument<T> In<T>(this OutArgument<T> self)
        {
            return new InArgument<T>(context => self.Get(context));
        }
        #endregion
        #region Out
        public static OutArgument<T> Out<T>(this InArgument<T> self)
        {
            return new OutArgument<T>(context => self.Get(context));
        }
        public static OutArgument<T> Out<T>(this OutArgument<T> self)
        {
            return new OutArgument<T>(context => self.Get(context));
        }
        #endregion
    }
