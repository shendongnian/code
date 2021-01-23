        public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //This sample shows invocation using a loosely typed object. 
            //Assumes you will send the correct object type to the property setter at runtime
            Dictionary<string, object> setupObjectValues = new Dictionary<string, object>();
            setupObjectValues.Add("Text", "Hello World");
            setupObjectValues.Add("ReadOnly", true);
            setupObjectValues.Add("Location", new Point(10, 5));
            foreach (string val in setupObjectValues.Keys)
            {
                UpdateControlObjectValue(textBox1, val, setupObjectValues[val]);
            }
        }
        public delegate void SetObjectPropertyDelegate(Control param, string PropertyName, object NewValue);
        public void UpdateControlObjectValue(Control sender, string PropertyName, object Value)
        {
            //Pass the method name into the delegate and match signatures
            //params collection used for parameters on method called in this case object and string
            sender.Invoke(new SetObjectPropertyDelegate(SetObjectProperty), sender, PropertyName, Value);
        }
        //Called by delegate (Matches signature of SetObjectPropertyDelegate)
        private void SetObjectProperty(Control sender, string PropertyName, object NewValue)
        {
            if (sender == null || String.IsNullOrEmpty(PropertyName) || NewValue == null)
                throw new ArgumentException("Invalid Argument");
            try
            {
                //Guaranteed to be a control due to strong typing on parameter declaration
                sender.GetType().GetProperty(PropertyName).SetValue(sender, NewValue, null);
                //Set Value on MSDN doc : http://msdn.microsoft.com/en-us/library/xb5dd1f1.aspx
            }
            catch (System.Reflection.AmbiguousMatchException ex)
            {
                //Two properties were found that match your Property Name
            }
            catch (ArgumentNullException ex)
            {
                //Null Property Found
            }
            catch (ArgumentException ex)
            {
                //Invalid Argument
            }
            catch (System.Reflection.TargetException ex)
            {
                //Invalid Target
            }
            catch (System.Reflection.TargetParameterCountException ex)
            {
                //Invalid number of parameters passed to reflection invoker
            }
            catch (System.MethodAccessException ex)
            {
                //Could not access the method to invoke it
            }
            catch (System.Reflection.TargetInvocationException ex)
            {
                //Problem invoking the target method
            }
            catch (Exception ex)
            {
                //serious problem
            }
        }
    }
}
