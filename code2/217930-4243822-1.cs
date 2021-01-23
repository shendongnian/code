    public class MyForm : Form {
        protected override void OnLoad( EventArgs e ) {
            // the base method raises the load method
            base.Load( e );
    
            // now are all events hooked to "Load" method proceeded => the form is loaded
            this.OnLoadComplete( e );
        }
    
        // your "special" method to handle "load is complete" event
        protected virtual void OnLoadComplete ( e ) { ... }
    }
