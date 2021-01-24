public class MyClass {
    public static readonly MyClass DefaultInstance = new MyClass();
    public int Val1 { get; set; }
    public int Val2 { get; set; }
    // Etc...
    public MyClass() {
        this.Val1 = 10;
    }
    public override int GetHashCode()
    {
        unchecked // Overflow is fine, just wrap
        {
            int hash = 17;
            // Suitable nullity checks etc, of course :)
            hash = hash * 23 + Val1.GetHashCode();
            hash = hash * 23 + Val2.GetHashCode();
            
            return hash;
        }
    }
    public override bool Equals(Object obj) {
        if (obj == this) 
        {
            return true;
        }
        var other = obj as MyClass;
        return other?.Val1 == this.Val1 && 
               other?.Val2 == this.Val2;
        // Etc...
    }
}
Then you can just check using:
    if (MyClass.DefaultInstance.Equals(instanceToCheck)) {
    ... // All defaults
    }
