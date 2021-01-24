    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var surface = new MyDesignSurface();
            var host = (IDesignerHost)surface.GetService(typeof(IDesignerHost));
            var selectionService = (ISelectionService)surface.GetService(typeof(ISelectionService));
            surface.BeginLoad(typeof(Form));
            var root = (Form)host.RootComponent;
            var tableLayoutPanel1 = (Control)host.CreateComponent(typeof(TableLayoutPanel), "tableLayoutPanel1");
            root.Controls.Add(tableLayoutPanel1);
            var view = (Control)surface.View;
            view.Dock = DockStyle.Fill;
            this.Controls.Add(view);
            selectionService.SetSelectedComponents(new[] { tableLayoutPanel1 });
            var propertyGrid1 = new PropertyGrid() { Dock = DockStyle.Right, Width = 200 };
            this.Controls.Add(propertyGrid1);
            propertyGrid1.SelectedObjects = selectionService.GetSelectedComponents().Cast<object>().ToArray();
        }
    }
