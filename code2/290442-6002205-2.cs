    public abstract class BasePage : Page
    {
            /// <summary>
            /// Called when loading the page.
            /// </summary>
            /// <param name="e">The event arguments.</param>
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
    
                // Do some basic setup.
    
                // Now pass the controls to the derived classes.
                this.ConfigureControl(this.mainText);
                this.ConfigureControl(this.nameDropDown);
                this.ConfigureControl(this.someOtherControl);            
            }
    
            /// <summary>
            /// Provides hook for derived classes.
            /// </summary>
            /// <param name="control">The core control.</param>
            protected virtual void ConfigureControl(Control control)
            {
            }
     }
