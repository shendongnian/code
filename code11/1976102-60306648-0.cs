    using System;
    using NUnit.Framework.Interfaces;
    using NUnit.Framework.Internal.Commands;
    namespace NUnit.Framework
    {
      [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
      public class RetryTestCaseAttribute : TestCaseAttribute, IRepeatTest
      {
        // You may not need all these constructors, but use at least the first two
        public RetryTestCaseAttribute(params object[] arguments) : base(arguments) { }
        public RetryTestCaseAttribute(object arg) : base(arg) { }
        public RetryTestCaseAttribute(object arg1, object arg2) : base(arg1, arg2) { }
        public RetryTestCaseAttribute(object arg1, object arg2, object arg3) : base(arg1, arg2, arg3) { }
        public int MaxTries { get; set; }
        // Should work, because NUnit only calls through the interface
        // Otherwise, you would delegate to a `new` non-interface `Wrap` method.
        TestCommand ICommandWrapper.Wrap(TestCommand command)
        {
          return new RetryAttribute.RetryCommand(command, MaxTries);
        }
      }
    }
