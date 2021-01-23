    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    
    public class Form1 : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    
        List<Entity> items = new List<Entity>()
        {
            new Entity(EntityType.Vehicle, "Car"),
            new Entity(EntityType.Vehicle, "Aeroplane"),
            new Entity(EntityType.Vehicle, "Truck"),
            new Entity(EntityType.Vehicle, "Bus"),
            new Entity(EntityType.Facility, "Garage"),
            new Entity(EntityType.Facility, "House"),
            new Entity(EntityType.Facility, "Shack"),
        };
    
        ListBox listBox;
        ComboBox comboBox;
    
        public Form1()
        {
            Text = "Filtering Demo";
            ClientSize = new Size(500, 320);
            Controls.Add(listBox = new ListBox
            {
                Location = new Point(10, 10),
                Size = new Size(200, 300),
            });
            Controls.Add(comboBox = new ComboBox
            {
                Location = new Point(230, 10),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Items = { "All", EntityType.Vehicle, EntityType.Facility },
                SelectedIndex = 0,
            });
    
            comboBox.SelectedIndexChanged += UpdateFilter;
            UpdateFilter(comboBox, EventArgs.Empty);
        }
    
        void UpdateFilter(object sender, EventArgs e)
        {
            var filtered = items.Where((i) => comboBox.SelectedItem is string || (EntityType)comboBox.SelectedItem == i.EntityType);
            listBox.DataSource = new BindingSource(filtered, "");
        }
    }
    
    enum EntityType { Vehicle, Facility, }
    
    class Entity : INotifyPropertyChanged
    {
        public string Name { get; private set; }
        public EntityType EntityType { get; private set; }
        public Entity(EntityType entityType, string name) { EntityType = entityType; Name = name; }
        public override string ToString() { return Name ?? String.Empty; }
        // Implementing INotifyPropertyChanged to eliminate (caught) BindingSource exceptions
        public event PropertyChangedEventHandler PropertyChanged;
    }
