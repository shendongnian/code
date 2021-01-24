public class Robot{
   
    public ShootPeopleWith( weapon IWeapon ){
        weapon.PressTrigger()
    }
}
interface IWeapon{
   PressTrigger()
}
You see the Robot expects anyone who wants it to shoot people to provide him with a weapon first. Now, he doesn't know what weapon. Whatever you provide me, it should have a trigger because I only know to press the trigger and I know it serves my purpose. If you provide me with something that doesn't have a trigger, I cannot function.
Now, there comes a drone that instructs the Robot to shoot people. It also provides it with a gun.
public class Drone{
    List<Robots> allRobotsInArea = someList
    public DelegateARobot(){
        robot = select a robot from allRobotsInArea
        IWeapon weapon = new MachineGun();    //procuring a machine gun
        robot.ShootPeopleWith(weapon);
    }
    
}
You can see here that IWeapon is an agreement between the Robot and Drone. It says that whatever you give me must have a trigger. So, machine gun must have a trigger. Let's implement few weapons:-
public class MachineGun : IWeapon{
    public PressTrigger(){
        Fire40RoundsPerSecond();
    }
    ...
}
public class Sniper() : IWeapon{
    public PressTrigger(){
        SayQuackQauck();
    }
}
The Drone can now easily pass in any weapon like Sniper and MachineGun to the Robot.
public class AssassinsSword{
    public CutInFour(){
        SwipeBlades();
    }
}
The drone cannot pass in the sword as `robot.ShootPeopleWith(new AssassinsSword());` because it doesn't have a trigger and breaches the contract that Robot expects.
In your case, the Android Operating System is possibly the Robot in the above story which expects anything of type INativePages so when it consumes your NativePages object, it will try to call StartActivityInAndroid(). It doesn't know the activity or how to start it, so you must specify it in the method. Pressing Alt + Enter in Windows will auto-generate this method for you. You will have to then write logic on how to Start the Activity in Android.
