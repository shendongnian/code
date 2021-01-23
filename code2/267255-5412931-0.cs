    public class EffectView : INotifyPropertyChanged
    {
    
        ObservableCollection<EffectsAndDescriptions> effects;
        public ObservableCollection<EffectAndDescriptions> Effects
        {
            get { return this.effects; }
            set
            {
                this.effects = value;
                this.RaisePropertyChanged ( "EffectsAndDescriptions" );
            }
        }
    
    }
    
    internal class EffectsAndDescriptions
    {
        public Effect Effect { get; set; }
        public Description Description { get; set; }
    }
