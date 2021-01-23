    public static class GivenController
    {
        public static ActionExpectations<T> As<T>(T controller) where T: Controller, new()
        {
            return new ActionExpectations<T> { MockController = controller };
        }
    }
