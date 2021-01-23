    public abstract class Animal
    {
        public abstract void Move();
    
        public virtual void MakeSignatureSound() 
        {
            Console.WriteLine("Ugggg");
        }
    }
    
    public class Dog : Animal 
    {
        public override void Move() 
        {
            RunLikeAPuppy();
        }
    
        public override void MakeSignatureSound()
        {
            Console.WriteLine("Woof");
        }
    }
    
    public class CaveMan : Animal
    {
        public override void Move() 
        {
            RunLikeANeanderthal();
        }
    }
    
    public class Cat : Animal
    {
        public override void Move() 
        {
            RunLikeAKitteh();
        }
    
        public override void MakeSignatureSound()
        {
            Console.WriteLine("Meioww");
        }
    }
