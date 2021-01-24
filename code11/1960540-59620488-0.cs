public static T DecoratorActions<T>(string desc, Func<T> func)
        {
            return Log(desc, () => ImpersonateAndAct(func));
        }
        public static void DecoratorActions(string desc, Action action)
        {
            Log(desc, () => ImpersonateAndAct(action));
        }
        public string Read(string filepath)
        {
            return DecoratorActions($"Reading file at '{filepath}'",
                () => fileService.Read(filepath));
        }
Based on these very helpful answers I've been able to determine that, while I may not be able to automatically wrap all methods of a class. I can at least reduce boilplate code and separate concerns by using the Decorator Pattern instead of the standard inheritance.
As such I have a Log method which calls "Entering {methodName}" and "Exiting {methodName}" as well as try/catching for exceptions which it also logs before throwing.
Additionally an inline way of impersonating for a specific action in the ImpersonateAndAct method.
Both of these return type of T so they wrap calls to my decorated fileService without interfering with the products of those methods.
I marked @Xander as the correct answer as he was the chief inspiration for this approach but I wanted to leave an answer to share what I came up with.
