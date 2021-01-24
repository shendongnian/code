C#
class SuperBot
{
    // can clean, move and bark
    public Dog o1;
    public Robot o2;
    public CleanRobot o3;
    public SuperBot(Dog dog, Robot robot, CleanRobot cleanRobot)
    {
        this.o1 = dog;
        this.o2 = robot;
        this.o3 = cleanRobot;
    }
    public void Bark() => o1.Bark();
    public void Move() => o2.Move();
    public void Clean() => o3.Clean();
}
This will solve your compiler error. Also if you add more methods to `Dog`, `Robot` or `CleanRobot`, they will not impact what the `SuperBot` offers, i.e. if `Dog` has a method `Eat()`, `SuperBot` will not have this method unless you add it as well.
Conceptually you use composition like this, if you model a `SuperBot` as actually consisting of a `Dog`, a `Robot` and a `CleanRobot`. The `SuperBot` then uses its `Dog` to bark and its `CleanRobot` to clean.
