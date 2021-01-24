    public class TurnoDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Turno1Template{ get; set; }
        public DataTemplate Turno2Template{ get; set; }
        public DataTemplate Turno2Template{ get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            TurnoType type = ((Turno)item).Type;
            switch (type)
            {
                case TurnoType.One:
                    return Turno1Template;
                case TurnoType.Two:
                    return Turno2Template;
                case TurnoType.Three:
                    return Turno3Template;
                default:
                    return null;
            }
        }
    }
