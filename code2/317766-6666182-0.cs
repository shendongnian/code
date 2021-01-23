    public sealed partial class ObservableCollectionExample : Form
    {
    private ObservableCollectionExample()
    {
         InitializeComponent();
    }
    private ObservableCollectionExample_Load(object sender, EventArgs e)
    {
          //Subscribe to the collection changed event
          Brands.CollectionChanged += new EventArgs<NotifyCollectionChangedEventHandler>(Brands_Changed);
    }
    
    private Brands_Changed(object sender, EventArgs e)
    {
          //Add code to do something when the Brands collection is changed i.e. something is added or removed via the .Add or .Remove method
    }
    
    private void Button_Click(object sender, EventArgs e)
    {
         if (_selectedBrand != null)
         {
              Brands.Add(foobar);
              if (_dataContext.Brands.First<Brand>(b => b.BrandID == selectedBrandID)) // Do some checking to see if it got added to the collection
              {
              SelectedBrand = _selectedBrand.BrandId;
              }
         }
    }
    }
