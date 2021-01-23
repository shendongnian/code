    public class ParentView : UIView
    {
      UILabel Label;
      MyTextView Text;
        
     /*Magic line here that fixed the problem */
     public override UIView InputAccessoryView {get{return Text.InputAccessoryView;}}
    }
    
    public class MyTextView : UITextView
    {
      UIView Accessory;
    
      public override UIView InputAccessoryView {get{return Accessory;}}
    }
