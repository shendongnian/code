    public abstract class FormBase : Form
    {
        public virtual event EventHandler MyEventHandler;
    }
    public class Form3 : FormBase
    {
        public override event EventHandler MyEventHandler;
        Form2 instance;
        public Form3()
        {
            instance = Form2.Instance;
            instance[this.GetType().ToString()] = this;
            // or 
            //instance["Form3"] = this;
        }
        private void dataGridView1_CellEndEdit(object sender, EventArgs e)
        {
            // todo
            if (MyEventHandler != null)
                MyEventHandler(this, e);
        }
    }
    public class Form2
    {
        Dictionary<string, FormBase> dic = new Dictionary<string,FormBase>();
        public FormBase this[string index]
        {
            get 
            { 
                FormBase retVal = null;
                if (dic.TryGetValue(index, out retVal))
                    return retVal;
                return null;
            }
            set
            {
                FormBase retVal = null;
                if (value == null)
                    return;
                if (dic.TryGetValue(index, out retVal))
                {
                    try
                    {
                        value.MyEventHandler -= MyEventHandler1;
                    }
                    catch
                    { 
                    }
                    retVal = value;
                    retVal.MyEventHandler += MyEventHandler1;
                    return;
                }
                value.MyEventHandler += MyEventHandler1;
                dic.Add(index, value);
            }
        }
        private static Form2 instance;
        public static Form2 Instance
        {
            get
            {
                if (instance == null)
                { 
                    instance = new Form2();
                }
                return instance;
            }
        }
        private Form2()
        {
        }
        private void MyEventHandler1(object sender, EventArgs e)
        {
        }
    }    
