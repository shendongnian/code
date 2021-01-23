public interface IABInterface
{
    //Whatever is common to A and B. It will have to be implemented in the classes
}
public interface IACInterface
{
    //Whatever is common to A and C. It will have to be implemented in the classes
}
public interface ICDInterface
{
    //Whatever is common to C and D. It will have to be implemented in the classes
}
public class ABCDBase
{
    //Whatever is common to all classes
}
public class A : ABCDBase, IABInterface, IACInterface
{
}
public class B : ABCDBase, IABInterface
{
}
public class C : ABCDBase, IACInterface, ICDInterface
{
}
public class D : ABCDBase, ICDInterface
{
}
