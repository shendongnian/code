    public partial class MainWindow : RibbonWindow
    {
    	private Size DefaultApplicationMenuSize;
    
    	public MainWindow()
    	{
    		InitializeComponent();
    	}
    
    	private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
    	{
    		var grid = (myRibbon.ApplicationMenu.Template.FindName("MainPaneBorder", myRibbon.ApplicationMenu) as Border).Parent as Grid;
    		/* before the first opening of the menu the size is NaN, so you have to measure size and use the DesiredSize */
    		grid.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
    		this.DefaultApplicationMenuSize = new Size(grid.DesiredSize.Width, grid.DesiredSize.Height);
    	}
    
    	private void RibbonApplicationMenuItem_MouseEnter(object sender, MouseEventArgs e)
    	{           
    		Button b=new Button();
    		b.Content = "my epic button";
    		b.Width = 500;
    		b.Height = 500;
    		b.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
    		SetApplicationMenuSize(b.DesiredSize);
    		this.ribbonContentPresenter.Content = b;
    	}
    
    	private void RibbonApplicationMenuItem_MouseLeave(object sender, MouseEventArgs e)
    	{
    		SetApplicationMenuSize(DefaultApplicationMenuSize);
    		this.ribbonContentPresenter.Content = null; 
    	}
    
    	private void SetApplicationMenuSize(Size size)
    	{
    		var grid = (myRibbon.ApplicationMenu.Template.FindName("MainPaneBorder", myRibbon.ApplicationMenu) as Border).Parent as Grid;
    		/* you can modify the width of the whole menu */
    		//grid.Width = size.Width;
    		/* or just the size of RibbonApplicationMenu.AuxiliaryPaneContent */
    		grid.ColumnDefinitions[2].Width = new GridLength(size.Width);
    		grid.Height = size.Height;
    	}
    }
