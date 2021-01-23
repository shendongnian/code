    public class Animal
    {
        public virtual void Eat()
        {
            // TODO : Provide some common implementation for an eating animal
        }
    }
    public class Cat: Animal
    {
    }
    
    public class Dog: Animal
    {
        public override void Eat()
        {
            // TODO: Some specific behavior for an eating dog like
            // doing a mess all around its bowl :-)
            base.Eat();
        }
    }
