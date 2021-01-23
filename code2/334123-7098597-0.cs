        namespace SO_Forms_Demo
    {
       public partial class Form1 : Form
       {
          List<person> people;
          public Form1()
          {
             InitializeComponent();
    
             List<string> dataList = new List<string>(){"Moe","Larry","Curly"};
             listBox1.DataSource = dataList;
    
              people = new List<person>(){new person(){name="Moe",age=44,shoeSize=9},
                                           new person(){name="Larry",age=45,shoeSize=10},
                                           new person(){name="Curly",age=46,shoeSize=11}
                                          };
              bindList2();
          }
    
          private void button1_Click(object sender, EventArgs e)
          {
             person Shemp = new person() { name = "Shemp", age = 49, shoeSize = 12 };
             people.Add(Shemp);
             bindList2();
          }
    
          private void bindList2()
          {
             listBox2.DataSource = null;
             listBox2.DisplayMember = "name";
             listBox2.DataSource = people;
          }
    
       }
    
       public class person
       {
          public string name { get; set; }
          public int age { get; set; }
          public int shoeSize { get; set; }
       }
    
    
    }
