    public class Configuration {
        private Control container;
        public Control Container {
            get {
                var result = this.container;
                if ( null == result ) {
                    this.container = result = new Container();
                }
            }
            set { this.container = value; }
        }
    }
    
    // ... elsewhere ...
    var cfg = new Configuration();
    cfg.Container.Controls.Add(new Button());
