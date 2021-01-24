csharp
public partial class frmVentes : Window
{
    private CollectionsDiverses _ColDiv;
    public frmVentes()
    {
        InitializeComponent();
        this._ColDiv = MainWindow.ColDiv;
    }
//...
In your main code, it looks like this :
csharp
public partial class MainWindow : Window
{
    public static CollectionDiverses ColDiv = new CollectionsDiverses();
    public MainWindow()
    {
        InitializeComponent();
    }
//...
Now in your CollectionsDiverses class you want to change it to public like this
csharp
public class CollectionsDiverses
{
//...
You will have to create an internal proprety for your list :
csharp
private List<Client> client = new List<Client>();
private List<Inventaire> inventaire = new List<Inventaire>();
//...
internal List<Client> Client { get => client; set => client = value; }
internal List<Vente> VenteArticle { get => venteArticle; set => venteArticle = value; }
//...
That's it ! It's now fixed, and I can use the information between different forms!
