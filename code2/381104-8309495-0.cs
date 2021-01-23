    public class MyTableSource : UITableViewSource
    {
    
        private BasisViewController controller;
        public MyTableSource(BasisViewController parentController)
        {
            this.controller = parentController;
        }
        
        //use like this in a method:
        //this.controller.NavigationController.PushViewController(opskrift, true);
    }
