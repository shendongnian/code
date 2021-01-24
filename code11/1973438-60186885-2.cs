       public partial class Mapper
        {
            public void MapToModel (BarViewModel viewmodel,Bar model)
            {
                model.Width = viewmodel.SettingsBarWidth;
            }
        }
