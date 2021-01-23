    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    public class BookDetails
    {
        public string Title { get; set; }
        public int TotalRating { get; set; }
        public int Occurrence { get; set; }
        public List<int> Rating { get; set; }
    }
    class BookList : List<BookDetails>, ITypedList
    {
    
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            var origProps = TypeDescriptor.GetProperties(typeof(BookDetails));
            List<PropertyDescriptor> newProps = new List<PropertyDescriptor>(origProps.Count);
            PropertyDescriptor doThisLast = null;
            foreach (PropertyDescriptor prop in origProps)
            {
    
                if (prop.Name == "Rating") doThisLast = prop;
                else newProps.Add(prop);
            }
            if (doThisLast != null)
            {
                var max = (from book in this
                           let rating = book.Rating
                           where rating != null
                           select (int?)rating.Count).Max() ?? 0;
                if (max > 0)
                {
                    // want it nullable to account for jagged arrays
                    Type propType = typeof(int?); // could also figure this out from List<T> in
                                                  // the general case, but make it nullable
                    for (int i = 0; i < max; i++)
                    {
                        newProps.Add(new ListItemDescriptor(doThisLast, i, propType));
                    }
                }
            }
            return new PropertyDescriptorCollection(newProps.ToArray());
        }
    
        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return "";
        }
    }
    class ListItemDescriptor : PropertyDescriptor
    {
        private static readonly Attribute[] nix = new Attribute[0];
        private readonly PropertyDescriptor tail;
        private readonly Type type;
        private readonly int index;
        public ListItemDescriptor(PropertyDescriptor tail, int index, Type type) : base(tail.Name + "[" + index + "]", nix)
        {
            this.tail = tail;
            this.type = type;
            this.index = index;
        }
        public override object GetValue(object component)
        {
            IList list = tail.GetValue(component) as IList;
            return (list == null || list.Count <= index) ? null : list[index];
        }
        public override Type PropertyType
        {
            get { return type; }
        }
        public override bool IsReadOnly
        {
            get { return true; }
        }
        public override void SetValue(object component, object value)
        {
            throw new NotSupportedException();
        }
        public override void ResetValue(object component)
        {
            throw new NotSupportedException();
        }
        public override bool CanResetValue(object component)
        {
            return false;
        }
        public override Type ComponentType
        {
            get { return tail.ComponentType; }
        }
        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            var data = new BookList {
                new BookDetails { Title = "abc", TotalRating = 3, Occurrence = 2, Rating = new List<int> {1,2,1}},
                new BookDetails { Title = "def", TotalRating = 3, Occurrence = 2, Rating = null },
                new BookDetails { Title = "ghi", TotalRating = 3, Occurrence = 2, Rating = new List<int> {3, 2}},
                new BookDetails { Title = "jkl", TotalRating = 3, Occurrence = 2, Rating = new List<int>()},
            };
            Application.Run(new Form
            {
                Controls = {
                    new DataGridView {
                        Dock = DockStyle.Fill,
                        DataSource = data
                    }
                }
            });
    
        }
    }
