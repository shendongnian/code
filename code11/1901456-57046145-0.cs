    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp
    {
        public class DaftarBarang
        {
            public string Nama { get; set; }
            public int Harga { get; set; }
        }
    
        public class TheUserControl : UserControl
        {
            private readonly BindingList<DaftarBarang> list = new BindingList<DaftarBarang>();
    
            public TheUserControl()
            {
                var grid = new DataGridView
                {
                    DataSource = new BindingSource(list, null)
                };
    
                AutoSize = true;
                Controls.Add(grid);
            }
    
            public void AddItem(DaftarBarang barang)
            {
                list.Add(barang);
            }
        }
    
        public class TheForm : Form
        {       
            public TheForm()
            {
                var uc = new TheUserControl();
                uc.AddItem(new DaftarBarang { Nama = "Sepatu olahraga", Harga = 255000 });
                uc.AddItem(new DaftarBarang { Nama = "Baju cantik", Harga = 85000 });
               
                Controls.Add(uc);
             }
        }
    
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.Run(new TheForm());
            }
        }
    }
