// This works
Animal a = new Cat();
// This does not work
Cat a = new Animal();
Now when you assign a cat to an animal and you have overriden the `Move` function, that means that the cat will always move as a cat whether or not you access it as an animal. You can't cast a cat to an animal as it is already an animal. `(cat as Animal)` does nothing.
Same way you can't cast `classB` to `classA` since B is already an A and will always behave as a B.
## Edit 2: Possible solution
public abstract class Mouse {
    
    public int x {get; set;}
    public int y {get; set;}
    public Mouse(x,y) {
        this.x = x;
        this.y = y;
    }
    public virtual void Move() {
        this.x++;
        this.y++;
    }
    public virtual void Move(x, y) {
        this.x+= x;
        this.y+= y;
    }
}
public class HumanMouse: Mouse {
   // whatever
   public HumanMouse(): base(1,1) {
   }
}
public class RoboticMouse: Mouse {
   public static int
   // whatever
   public RoboticMouse(): base(2,2) {
   }
}
Mouse m = new HumanMouse();
m.Move();
m.Move(1,2); 
// or
Mouse m2 = new RoboticMouse();
m.Move();
m.Move(m2.x,m2.y); 
  [1]: https://docs.microsoft.com/el-gr/dotnet/csharp/language-reference/operators/user-defined-conversion-operators
