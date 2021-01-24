    public class ComputerTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SelectedComputer { get; set; }
        public DataTemplate Computer { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((SQLite_Database.Computer)item).Selected == true ? SelectedComputer : Computer;
        }
    }
