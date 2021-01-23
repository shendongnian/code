    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadEventRegister loadEventRegister = new LoadEventRegister();
            Form[] formInstances = new Form[] {new Form2(), new Form3()};
            loadEventRegister.RegisterLoadOnForms(formInstances);
            foreach (Form formInstance in formInstances)
            {
                formInstance.Show();
            }
        }
    }
    public class LoadEventRegister
    {
        public void RegisterLoadOnForms(IEnumerable<Form> formInstances)
        {
            foreach (Form formInstance in formInstances)
            {
                EventInfo eventInfo = formInstance.GetType().GetEvent("Load");
                Type eventHandlerType = eventInfo.EventHandlerType;
                MethodInfo eventHandler = this.GetType().GetMethod("Generic_Load");
                Delegate d = Delegate.CreateDelegate(eventHandlerType, this, eventHandler);
                eventInfo.AddEventHandler(formInstance, d);
            }
        }
        public void Generic_Load(object sender, EventArgs e)
        {
            MyCustomLoad();
        }
        private void MyCustomLoad()
        {
            // Do something
        }
    }
