    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private List<Part> parts;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                parts = new List<Part>();
                parts.Add(new Part("Hammer #1", 1, 5, 3));
                parts.Add(new Part("Hammer #2", 1, 5, 4));
                parts.Add(new Part("Hammer #3", 1, 1, 6));
    
                parts.Add(new Part("Nail #1", 7, 10, 14));
                parts.Add(new Part("Nail #2", 8, 10, 13));
                parts.Add(new Part("Nail #3", 9, 10, 15));
    
                parts.Add(new Part("Screw", 16, 17, 18));
    
                var results = parts.GroupBy(part => new {part.PartLength, part.PartMark})
                    .Select(grouped => new GroupedPart()
                    {
                        PartLength = grouped.Key.PartLength,
                        PartMark = grouped.Key.PartMark,
                        Parts = grouped.ToList()
                    })
                    .OrderBy(p => p.Parts.Sum(part => part.Number));
    
                List<GroupedPart> groupedParts = results.ToList();
    
                dataGridView1.DataSource = groupedParts;
            }
        }
    }
