    public class MyControl: MyDesignableControl
    {
    }
    [Designer(typeof(DocumentDesigner), typeof(IRootDesigner))]
    public class MyDesignableControl : Panel
    {
    }
