    public class Cat : Parent<Cat, Kitten>
    {
    }
    
    public class Kitten : Child<Cat, Kitten>
    {
    }
    
    public class Dog : Parent<Dog, Puppy>
    {
    }
    
    public class Puppy : Child<Dog, Puppy>
    {
    }
