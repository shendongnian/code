       public partial class Mapper
        {
            public Bar map (BarViewModel viewmodel)
            {
                return new Bar { Width = viewmodel.SettingsBarWidth};
            }
        }
