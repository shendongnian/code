    using AutoPoco.Engine;
    using AutoPoco;
    using AutoPoco.DataSources;
    
    namespace GridViewSorting
    {
        public partial class TestForm : Form
        {
            public TestForm()
            {
                InitializeComponent();
            }
    
            private void TestForm_Load(object sender, EventArgs e)
            {
                LoadGridData();
            }
    
            private void gv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                var newcolumn = gv.Columns[e.ColumnIndex];
                var showColumn = newcolumn;
    
                ListSortDirection direction;
                var sortedColumn = gv.SortedColumn;
    
                var sd = sortedColumn==null? SortOrder.None:sortedColumn.HeaderCell.SortGlyphDirection;
    
                if (sortedColumn == newcolumn && sd == gv.SortOrder)
                    return;
    
                if (sd == SortOrder.Descending || sd == SortOrder.None)
                {
                    sd = SortOrder.Ascending;
                    direction = ListSortDirection.Ascending;
                }
                else
                {
                    sd = SortOrder.Descending;
                    direction = ListSortDirection.Descending;
                }
    
                //now the fun begins, suppose this is image column and you want to 
                //sort based on product name when product image column header
                //is clicked.
    
                if (newcolumn.HeaderText == "ProductImage")//check if image column
                {
                    newcolumn = gv.Columns["ProductName"];//sort on product names
                }
    
                gv.Sort(newcolumn, direction);
                newcolumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                showColumn.HeaderCell.SortGlyphDirection = sd;//change sort indicator on clicked column
            }
    
            private void LoadGridData()
            {
                IGenerationSessionFactory factory = AutoPocoContainer.Configure(x =>
                {
                    x.Conventions(c => { c.UseDefaultConventions(); });
                    x.AddFromAssemblyContainingType<SimpleProduct>();
    
                    x.Include<SimpleProduct>()
                        .Setup(c => c.ProductName).Use<FirstNameSource>()
                        .Setup(c => c.Id).Use<IntegerIdSource>()
                        .Setup(c => c.ProductDescription).Use<RandomStringSource>(5, 20);
                });
    
                var session = factory.CreateSession();
                var r = new Random(234234);
                var rn = r.Next(5, 100);
                IList<SimpleProduct> products = session.List<SimpleProduct>(25)
                    .Impose(x => x.Price, r.Next() * rn)
                    .Get();
                var bl = new ProductList();
    
                foreach (var i in products)
                {
                    bl.Add(i);
                }
    
                gv.DataSource = bl;
            }
        }
    
        public class ProductList : SortableProductList<SimpleProduct>
        {
            protected override Comparison<SimpleProduct> GetComparer(PropertyDescriptor prop)
            {
                Comparison<SimpleProduct> comparer;
                switch (prop.Name)
                {
                    case "Id":
                        comparer = new Comparison<SimpleProduct>(delegate(SimpleProduct x, SimpleProduct y)
                        {
                            if (x != null)
                                if (y != null)
                                    return (x.Id.CompareTo(y.Id));
                                else
                                    return 1;
                            else if (y != null)
                                return -1;
                            else
                                return 0;
                        });
                        break;
                    case "ProductName":
                        comparer = new Comparison<SimpleProduct>(delegate(SimpleProduct x, SimpleProduct y)
                        {
                            if (x != null)
                                if (y != null)
                                    return (x.ProductName.CompareTo(y.ProductName));
                                else
                                    return 1;
                            else if (y != null)
                                return -1;
                            else
                                return 0;
                        });
                        break;
                    case "ProductDescription":
                        comparer = new Comparison<SimpleProduct>(delegate(SimpleProduct x, SimpleProduct y)
                        {
                            if (x != null)
                                if (y != null)
                                    return (x.ProductDescription.CompareTo(y.ProductDescription));
                                else
                                    return 1;
                            else if (y != null)
                                return -1;
                            else
                                return 0;
                        });
                        break;
                    case "Price":
                        comparer = new Comparison<SimpleProduct>(delegate(SimpleProduct x, SimpleProduct y)
                        {
                            if (x != null)
                                if (y != null)
                                    return (x.Price.CompareTo(y.Price));
                                else
                                    return 1;
                            else if (y != null)
                                return -1;
                            else
                                return 0;
                        });
                        break;
                    default:
                        comparer = new Comparison<SimpleProduct>((x, y) =>
                        {
                            if (x != null && y != null)
                                return x.GetHashCode().CompareTo(y.GetHashCode());
                            return 0;
                        });
                        break;
                }
                return comparer;
            }
        }
    
        public abstract class SortableProductList<T> : BindingList<T>
        {
            protected override bool SupportsSortingCore{get{return true;}}
    
            protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
            {
    			if (prop.PropertyType.GetInterface("IComparable") == null)return;
                var itemsList = (List<T>)this.Items;
    
    			Comparison<T> comparer = GetComparer(prop);
    			itemsList.Sort(comparer);
    			if (direction == ListSortDirection.Descending) itemsList.Reverse();
            }
    
            protected abstract Comparison<T> GetComparer(PropertyDescriptor prop);
        }
    
        public class SimpleProduct
        {
            public int Id { get; set; }
            public string ProductName { get; set; }
            public decimal Price { get; set; }
            public string ProductImage { get; set; }
            public string ProductDescription { get; set; }
        }
    }
