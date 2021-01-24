c#
    public interface ILiving
    {
        Status LifeStatus
        {
            get; set;
        }
        Status GetLifeStatus();
        void Die();
    }
Used as:
c#
public class Lion : IAnimals
{
    //...
    void Die()
    {
        LifeStatus = Status.Dead;
    }
    //....
}
If I am getting this right, what you probably need as an answer is to **keep setters private and provide methods that express the behavior of your classes/interfaces instead**.
Imagine LifeStatus being arbitrarily set at various positions all over your code, and suddenly, _dying_ acquires a different meaning for your `IAnimals`. You will have to chase down all places where it has been set. Instead, if you have a method, you can do whatever you wish in the method, and all places where it has been invoked will not have to be changed in any way. You will "enforce" the new meaning directly inside the class.
Now, why _dying_ might change meaning, is a different story...
