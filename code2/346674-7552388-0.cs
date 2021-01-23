    public class ExRibbon : Ribbon
    {
        public override void OnApplyTemplate()
        {
             base.OnApplyTemplate();
                        
             if (!IsMinimizable)
             {
                  IsMinimizedProperty.OverrideMetadata(typeof(ExRibbon), 
                       new FrameworkPropertyMetadata(false, (o, e) => { }, (o,e) => false));
             }
        }
        public bool IsMinimizable { get; set; }
    }
