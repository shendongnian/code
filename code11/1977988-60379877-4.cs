public class Parent{
    public string Name { get; protected set; }
}
public class TemplateChild1: Parent
{
    public TemplateChild1(){
        Name = "Child one";
    }
}
public class TemplateChild2: Parent
{
    public TemplateChild2(){
        Name = "Child two";
    }
}
Now all the items in the combo, be they a Child1 or a Child2, show the text assigned to their Name property. The `set` is protected; it can only be accessed by children of the Parent. The constructors for the children set the value of Name, and it cannot then be set to something else (well.. except by another child. If you want to prevent that, make the children not inheritable), hence it's now constant
    
