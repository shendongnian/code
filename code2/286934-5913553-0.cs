    class CallContext<TInput, TOutput>
    {
        TInput InputValue { get; set; }
        TOutput OutputValue { get; set; }
        ICollection<String> Warnings { get; set; }
    }
    class MyService
    {
        void SomeOperation(CallContext<int, int> context)
        {
            context.OutputValue = context.InputValue * 2;
            if (context.IntputValue < 0)
                context.Warnings.Add("Input value less than zero may have undesired results.");
        }
    }
