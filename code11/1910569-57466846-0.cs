    public class MainWindow: Form {
        public MainWindow()
        {
            this.Build();
        }
        TabControl BuildTabs()
        {
            this.Tabs = new TabControl { Dock = DockStyle.Fill };
            this.Tabs.SelectedIndexChanged += (o, evt) => this.OnTabChanged();
            this.Tabs.TabPages.Add( new TabPage{ Text = "Tab1" } );
            this.Tabs.TabPages.Add( new TabPage{ Text = "Tab2" } );
            return this.Tabs;
        }
        void Build()
        {
            this.MinimumSize = new Size( 580, 460 );
            this.Text = "Programmatic creation";
            this.Controls.Add( this.BuildTabs() );
        }
        public TabControl Tabs {
            get; private set;
        }
    }
