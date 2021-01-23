    public class BaseButton : Button
    {
       ///
       protected override void OnPreRender(EventArgs e)
       {
          // Common base implementationi
       }         
    }
    
    public class ImageButton: BaseButton
    {
       // Specific implementation
       public ImageButton()
       {
          this.Name = "ImageButton";
       }
    }
    
    public class RoleButton: BaseButton
    {
       // Specific implementation
       public RoleButton()
       {
          this.Name = "RoleButton";
       }
    }
