    public partial class VariablesWindow : Window
    {
        public ObservableCollection<TemplateVariable> Variables { get; private set; }
        public VariablesWindow(IEnumerable<TemplateVariable> vars)
        {
            Variables = new ObservableCollection<TemplateVariable>(vars.DeepCopy());
