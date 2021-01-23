    public abstract class TerminalExpression : Expression
    {
        public override void Interpret(Context value)
        {
            while (value.Input - 9 * Multiplier() >= 0)
            {
                value.Output += Nine();
                value.Input -= 9 * Multiplier();
            }
            while (value.Input - 5 * Multiplier() >= 0)
            {
                value.Output += Five();
                value.Input -= 5 * Multiplier();
            }
            while (value.Input - 4 * Multiplier() >= 0)
            {
                value.Output += Four();
                value.Input -= 4 * Multiplier();
            }
            while (value.Input - Multiplier() >= 0)
            {
                value.Output += One();
                value.Input -= Multiplier();
            }
        }
        public abstract string One();
        public abstract string Four();
        public abstract string Five();
        public abstract string Nine();
        public abstract int Multiplier();
    }
