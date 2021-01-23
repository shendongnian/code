     public partial class Form1 : Form
    {
        IOrderController Controller;
        public order OrderToBeSaved { get; set; }
        public Form1()
        {
            InitializeComponent();
            Controller = new OrderBaseController(); // you have the controller , 
            // controller creation can also be delegated to some other component but that's totally different issue.
           
            OrderToBeSaved = Controller.GetOrder(); // You got the order object here , once you get the order object you can bind its properties to the different control.
            
            
        }
    }
