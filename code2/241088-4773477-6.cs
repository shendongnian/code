    public class SampleModel 
    {
        public IEnumerable<ViewData> Items
        {
            get
            {
                yield return new ViewData(Properties.Resources.airbrush_256, "item 1");
                yield return new ViewData(Properties.Resources.colors_256, "item 2");
                yield return new ViewData(Properties.Resources.distribute_left_edge_256, "item 3");
                yield return new ViewData(Properties.Resources.dossier_ardoise_images, "item 4");
            }
        }
    }
    public class ViewData
    {
        public ViewData(Bitmap icon, string name)
        {
            this._icon = icon;
            this._name = name;
        }
        private readonly Bitmap _icon;
        public Bitmap Icon
        {
            get
            {
                return this._icon;
            }
        }
        private readonly string _name;
        public string Name
        {
            get
            {
                return this._name;
            }
        }
    }
