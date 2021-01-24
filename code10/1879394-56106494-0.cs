namespace ConsoleApp1
{
    using Stateless;
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press Q to stop validating events");
            ConsoleKeyInfo c;
            do
            {
                var mpe = new MarketPriceEvent();
                mpe.Validate();
                c = Console.ReadKey();
            } while (c.Key != ConsoleKey.Q);
        }
    }
    public class MarketPriceEvent
    {
        public void Validate()
        {
            _machine.Fire(Trigger.Validate);
        }
        public enum State { Validate, Compare2, ErrorAuditing, Compare1, Storing }
        private enum Trigger { Validate, CompareOneOk, CompareTwoOk, Error, }
        private readonly StateMachine<State, Trigger> _machine;
        public MarketPriceEvent()
        {
            _machine = new StateMachine<State, Trigger>(State.Validate);
            _machine.Configure(State.Validate)
                .Permit(Trigger.Validate, State.Compare1);
            _machine.Configure(State.Compare1)
                .OnEntry(DoEventValidation)
                .Permit(Trigger.CompareOneOk, State.Compare2)
                .Permit(Trigger.Error, State.ErrorAuditing);
            _machine.Configure(State.Compare2)
                .OnEntry(DoEventValidationAgainstResource2)
                .Permit(Trigger.CompareTwoOk, State.Storing)
                .Permit(Trigger.Error, State.ErrorAuditing);
            _machine.Configure(State.Storing)
                .OnEntry(HandleStoring);
            _machine.Configure(State.ErrorAuditing)
                .OnEntry(HandleError);
        }
        private void DoEventValidation()
        {
            // Business logic goes here
            if (isValid())
                _machine.Fire(Trigger.CompareOneOk);
            else
                _machine.Fire(Trigger.Error);
        }
        private void DoEventValidationAgainstResource2()
        {
            // Business logic goes here
            if (isValid())
                _machine.Fire(Trigger.CompareTwoOk);
            else
                _machine.Fire(Trigger.Error);
        }
        private bool isValid()
        {
            // Returns false every five seconds...
            return (DateTime.UtcNow.Second % 5) != 0;
        }
        private void HandleStoring()
        {
            Console.WriteLine("Awesome, validation OK!");
        }
        private void HandleError()
        {
            Console.WriteLine("Oh noes, validation failed!");
        }
    }
}
