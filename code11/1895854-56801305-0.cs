    public class PressedEffect : RoutingEffect
    {
        public PressedEffect() : base("MyApp.PressedEffect")
        {
        }
    
        public static readonly BindableProperty LongPressedCommandProperty = BindableProperty.CreateAttached("LongPressedCommand", typeof(ICommand), typeof(PressedEffect), (object)null);
        public static ICommand GetLongPressedCommand(BindableObject view)
        {
            return (ICommand)view.GetValue(LongPressedCommandProperty);
        }
    
        public static void SetLongPressedCommand(BindableObject view, ICommand value)
        {
            view.SetValue(LongPressedCommandProperty, value);
        }
    
    
        public static readonly BindableProperty LongParameterProperty = BindableProperty.CreateAttached("LongParameter", typeof(object), typeof(PressedEffect), (object)null);
        public static object GetLongParameter(BindableObject view)
        {
            return view.GetValue(LongParameterProperty);
        }
    
        public static void SetLongParameter(BindableObject view, object value)
        {
            view.SetValue(LongParameterProperty, value);
        }
    
        public static readonly BindableProperty LongRelesedCommandProperty = BindableProperty.CreateAttached("LongRelesedCommand", typeof(ICommand), typeof(PressedEffect), (object)null);
        public static ICommand GetLongRelesedCommand(BindableObject view)
        {
            return (ICommand)view.GetValue(LongRelesedCommandProperty);
        }
    
        public static void SetLongRelesedCommand(BindableObject view, ICommand value)
        {
            view.SetValue(LongRelesedCommandProperty, value);
        }
    }
