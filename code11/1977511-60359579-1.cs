    public class Person
    {
        private int _Speed;
        private double _ReactionTime;
        private int _CalorieConsumptionPerHour;
        public Person(Stance stance) 
        {
            if (stance == Stance.Active)
                setToActive();
            else if (stance == Stance.Passive)
                setToPassive();
            else
                setToDefault();
        }
        private void setToActive()
        {
            _Speed = 30;
            _ReactionTime = .15;
            _CalorieConsumptionPerHour = 200;
        }
        private void setToPassive()
        {
            _Speed = 10;
            _ReactionTime = .5;
            _CalorieConsumptionPerHour = 100;
        }
        private void setToDefault()
        {
            _Speed = 20;
            _ReactionTime = .3;
            _CalorieConsumptionPerHour = 150;
        }
        public enum Stance
        {
            Active,
            Passive
        }
    }
