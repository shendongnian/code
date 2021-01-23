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
       public RoleImageButton()
       {
          this.Name = "RoleImageButton";
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
