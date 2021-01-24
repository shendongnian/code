public static System.Windows.Controls.ListView lv;
public static GridView gridView;
public MainWindow()
{
    InitializeComponent();
    SetupListView();//To Initializes List and its properties 
    SetupListViewHeaders();//adds Column headers
    Final();//Adding listview to Children for display
}
**Method Definition(s)**
private void SetupListView()
{
 lv = new System.Windows.Controls.ListView();            
 lv.Margin = new Thickness(10, 15, 0, 0);
 lv.Height = 500;
 lv.Width = 700;         
 gridView = new GridView();
 lv.View = gridView;           
}
private void SetupListViewHeaders()
{
    gridView.Columns.Add(new GridViewColumn
    {
                    Header = "Id",
                    DisplayMemberBinding = new Binding("Id")
    });
    gridView.Columns.Add(new GridViewColumn
    {
        Header = "Emp",
        DisplayMemberBinding = new Binding("Emp")
    });
    gridView.Columns.Add(new GridViewColumn
    {
        Header = "Basket",
        DisplayMemberBinding = new Binding("Basket")
    });
    gridView.Columns.Add(new GridViewColumn
    {
        Header = "Recipe",
        DisplayMemberBinding = new Binding("Recipe")
    });
    gridView.Columns.Add(new GridViewColumn
    {
        Header = "Time",
        DisplayMemberBinding = new Binding("Time")
    });
    for (int i = 1; i <= 25; i++)
    {
        gridView.Columns.Add(new GridViewColumn
        {
            Header = "Pos" + i.ToString(),
            DisplayMemberBinding = new Binding("Pos" + i.ToString())
        });
    }
}
    
        
private void Populate(String id, String emp, String basket, String recipe, String time, String pos1, String pos2, String pos3, String pos4, String pos5,
                             String pos6, String pos7, String pos8, String pos9, String pos10, String pos11, String pos12, String pos13, String pos14, String pos15, String pos16,
                             String pos17, String pos18, String pos19, String pos20, String pos21, String pos22, String pos23, String pos24, String pos25)
{ 
    lv.Items.Add(
    new
    {
        Id = 1, Emp = "David", Basket = basket, Recipe = recipe,
        Time = time, Pos1=pos1, Pos2=pos2, Pos3=pos3, Pos4=pos4, Pos5=pos5, Pos6=pos6, Pos7=pos7,Pos8=pos8,
        Pos9=pos9, Pos10=pos10, Pos11=pos11, Pos12=pos12, Pos13=pos13, Pos14=pos14, Pos15=pos15, Pos16=pos16,Pos17=pos17, Pos18=pos18,
        Pos19=pos19, Pos20=pos20, Pos21=pos21, Pos22=pos22, Pos23=pos23, Pos24=pos24, Pos25=pos25
    });
}      
      
        private void Final()
        {
            MainGrid.Children.Add(lv);
        }
