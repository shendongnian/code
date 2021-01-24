    public class BaseMasterForm : Form
    {
        // You can override this Show Background. If you want or not to show background.
        public virtual bool ShowBackground { get { return true; } }
    
        public BaseMasterForm()
        {
            this.Load += (s, e) =>
            {
                // your image
                this.BackgroundImage = (ShowBackground) ? Properties.Resources.LeeQc : null;
                // you can custom
                this.BackgroundImageLayout = (ShowBackground) ? ImageLayout.Stretch : ImageLayout.None;
            };
        }
    }
 
