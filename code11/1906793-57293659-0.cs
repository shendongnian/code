` language:csharp
public interface IComboItem {
    string Name {get; set;}
    object Value {get; set;}
}
public class Fruit : IComboItem {
    //fruit stuff
}
public class Shoe : IComboItem {
    //shoe stuff
}
//View
public interface IComboBoxModel
{
    void ShowComboBox(List<IComboItem> comboItems);    
}
//Presenter
public abstract class ComboBoxPresenter {
    IComboBoxView comboBoxView;
    public ComboBoxPresenter(IComboBoxView view){
        comboBoxView = view;
    }
    public void Init(){
        var model = GetModel();
        comboBoxView.ShowComboBox(model);
    }
    //force implementors to get the model
    private abstract List<IComboItem> GetModel();
}
public class FruitsComboBoxPresenter : ComboBoxPresenter
{
    private override List<Fruit> GetModel()
    {
        return GetFruitsFromDataBase(); //fake call to DB for fruits
    }
}
public class ShoeComboBoxPresenter : ComboBoxPresenter
{
    private override List<Shoe> GetModel()
    {
        return GetShoesFromDataBase(); //fake call to DB for fruits
    }
}
////////Code Behind Page////////
public partial class ExampleForm : Form, IComboBoxView
{
    public CategoryType categoryType { get; set; }
    IComboBoxPresenter comboBoxPresenter;
    public ExampleForm(CategoryType type)
    {
        categoryType = type; //user category selection
    }
    private void ExampleForm_Load(object sender, EventArgs e)
    {
        if (categoryType == CategoryType.Fruits)
        {
            comboBoxPresenter = new FruitsComboBoxPresenter(this);
        }
        else if (categoryType == CategoryType.Shoes)
        {
            comboBoxPresenter = new ShoesComboBoxPresenter(this);
        }
        else
        {
            throw new Exception("Invalid type detected");
        }
        comboBoxPresenter.Init();
    }
    public void ShowComboBox(List<IComboItem> comboItems)
    {
        comboBox.DataSource = comboItems.Select(x => x.Name).ToList();
    }
}
`
