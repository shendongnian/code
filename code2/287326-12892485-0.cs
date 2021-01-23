    public class Lamp : StateMachine
    {
        // Triggers (or events, or actions, whatever) that our
        // state machine understands.
        [Trigger]
        public readonly Action PressSwitch;
        [Trigger]
        public readonly Action GotError;
        // Actual state machine logic
        protected override IEnumerable WalkStates()
        {
        off:                                       
            Console.WriteLine("off.");
            yield return null;
            if (Trigger == PressSwitch) goto on;
            InvalidTrigger();
        on:
            Console.WriteLine("*shiiine!*");
            yield return null;
            if (Trigger == GotError) goto error;
            if (Trigger == PressSwitch) goto off;
            InvalidTrigger();
        error:
            Console.WriteLine("-err-");
            yield return null;
            if (Trigger == PressSwitch) goto off;
            InvalidTrigger();
        }
    }
