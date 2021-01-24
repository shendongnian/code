using System;
namespace ConsoleApp2
{
    public class data_to_pass //// Don't forget to use 'public'
    {
        //// Put your values here
        public int a_int_value { get; set; }
        public string a_string_value { get; set; }
        public bool a_boolean_value { get; set; }
    }
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //// Create your values
            data_to_pass new_data = new data_to_pass()
            {
                a_int_value = 10,
                a_string_value = "Not Set Yet",
                a_boolean_value = true
            };
            new Data_Picker_Form(new_data).ShowDialog();
            Console.WriteLine("Value is {0} , String is {1} , Bool is {2}",
             new_data.a_int_value, new_data.a_string_value, new_data.a_boolean_value);
            Console.ReadKey();
        }
    }
}
Example (Form):
-------
using System;
using System.Windows.Forms;
namespace ConsoleApp2
{
    public partial class Data_Picker_Form : Form
    {
        data_to_pass data_in_obj;
        public Data_Picker_Form(data_to_pass data_in)
        {
            InitializeComponent();
            data_in_obj = data_in;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            data_in_obj.a_string_value = "OUTPUT_VALUE";
            data_in_obj.a_int_value = 666;
            data_in_obj.a_boolean_value = false;
            this.Close();
        }
    }
}
**Output :**
> Value is 666 , String is OUTPUT_VALUE , Bool is False
Have fun ;)
