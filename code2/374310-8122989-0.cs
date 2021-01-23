     public partial class Form1 : Form
        {
            private Controller controller;
            public Form1()
            {
                InitializeComponent();
            }
            //Dependency Injection
            public Form1(Controller controller):this()
            {
                //add more defensive logic to check whether you have valid controller instance
                this.controller = controller;
            }
            private void button1_Click(object sender, EventArgs e)
            {
                if (controller != null)
                    controller.MethodA();
            }
        }
        //This will be another class/ controller for your view.
        public class Controller
        {
            public void MethodA() { }
        }
