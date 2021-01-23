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
