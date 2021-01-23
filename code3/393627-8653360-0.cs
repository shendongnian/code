    public static class RhinoExtensions
    {
        public static void AssertWasCalledWithMessage<T>(this T mock, Expression<Func<T, object>> action)
        {
            try
            {
                mock.AssertWasCalled(action.Compile());
            }
            catch (ExpectationViolationException)
            {
                Console.WriteLine(string.Format("{0} was not called with proper parameters or was not called.", (action.Body as MethodCallExpression).Method.Name));
                throw;
            }
        }
    }
