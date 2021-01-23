    void Main()
    {
        var controller = Controller.Create (c => new View (c));  
    }
    
    class Controller {
        private View view;
    
        // This could also be a constructor, but I prefer to think of this
        // as a factory method.
        public static Controller Create (Func<Controller, View> viewBuilder) {
            var controller = new Controller ();
            var view = viewBuilder (controller);
            controller.Initialize (view);
            return controller;
        }
        
        protected Controller() {
        }
        
        protected void Initialize (View view) {
            this.view = view;
        }
    }
    
    class View {
        private Controller controller;
        
        public View (Controller controller) {
            this.controller = controller;
        }
    }
