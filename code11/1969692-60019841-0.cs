    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace test
    {
        public partial class Form1 : Form
        {
            List<Items> STOCK = new List<Items>();
            public Form1()
            {
                InitializeComponent();
            }
    
            public void Form1_Load(object sender, EventArgs e)
            {
    
               this.STOCK = new List<Items>
               {
                new Items{ id = 1, Name = "Bun", Price = 100},
                new Items{ id = 2, Name = "Soda", Price = 80},
                new Items{ id = 3, Name = "Cheese", Price =70},
                new Items{ id = 4, Name = "Tissue", Price = 50},
                new Items{ id = 5, Name = "Fabuloso", Price = 140},
                new Items{ id = 6, Name = "Grace Mackerel", Price = 90},
                new Items{ id = 7, Name = "Rice", Price = 50},
                new Items{ id = 8, Name = "Flour", Price = 40},
                new Items{ id = 9, Name = "Sugar", Price = 30},
               };
    
    
    
                var STOCKDict = STOCK.ToDictionary(i => i.id);
    
                var selecteditems = new List<Items>();
    
            }
    
            public void textBox1_TextChanged(object sender, EventArgs e)
            {
                textBox1.Text = textBox1.Text + STOCK.ForEach(x => Console.WriteLine(string.Format("ID {0} - Name: {1,-20} Price: {2:C2}", x.id, x.Name, x.Price)));
            }
            public class Items
            {
                public int id { get; set; }
                public string Name { get; set; }
                public decimal Price { get; set; }
            }
        }
    }
