    public class MyButton : Button
    {
        [ReadOnly(true)]
        public sealed override Font Font
        { get { return new Font("Arial", 9F, FontStyle.Italic, GraphicsUnit.Point); } }
    
        [ReadOnly(true)]
        public sealed override Color ForeColor
        { get { return Color.Blue; } }
    
        public GDITButton()
        { }
    }
    
    
    public class MyExitButton : MyButton
    {
        [ReadOnly(true)]
        public override string Text
        { get { return "Exit"; } }
    
        public MyExitButton()
        {}
    }
    
    public class MyAddButton : MyButton
    {
        [ReadOnly(true)]
        public override string Text
        { get { return "Add"; } }
    
        public MyAddButton()
        {}
    }
