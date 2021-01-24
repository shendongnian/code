    [assembly: ResolutionGroupName("MyApp")]
    [assembly: ExportEffect(typeof(AndroidPressedEffect), "PressedEffect")]
    namespace LongPressedDemo.Droid
    {
        public class AndroidPressedEffect : PlatformEffect
        {
            private bool _attached;
            public AndroidPressedEffect()
            {
            }
    
            protected override void OnAttached()
            {
                if (!_attached)
                {
                    if (Control != null)
                    {
                        Control.LongClickable = true;
                        Control.Touch += Control_Touch;
                    }
                    else
                    {
                        Container.LongClickable = true;
                        Container.Touch += Control_Touch;
                    }
                    _attached = true;
                }
            }
    
            private void Control_Touch(object sender, Android.Views.View.TouchEventArgs e)
            {
                if (e.Event.Action == MotionEventActions.Down)
                {
                    var command = PressedEffect.GetLongPressedCommand(Element);
                    command?.Execute(PressedEffect.GetLongParameter(Element));
                }
                else if (e.Event.Action == MotionEventActions.Up)
                {
                    var command = PressedEffect.GetLongRelesedCommand(Element);
                    command?.Execute(PressedEffect.GetLongParameter(Element));
                }
            }
    
    
            protected override void OnDetached()
            {
                if (_attached)
                {
                    if (Control != null)
                    {
                        Control.LongClickable = true;
                        Control.Touch -= Control_Touch;
                    }
                    else
                    {
                        Container.LongClickable = true;
                        Container.Touch -= Control_Touch;
                    }
                    _attached = false;
                }
            }
        }
    }
