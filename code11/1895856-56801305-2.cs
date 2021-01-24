    [assembly: ResolutionGroupName("MyApp")]
    [assembly: ExportEffect(typeof(iOSPressedEffect), "PressedEffect")]
    namespace LongPressedDemo.iOS
    {
        public class iOSPressedEffect : PlatformEffect
        {
            private bool _attached;
            private readonly UILongPressGestureRecognizer _longPressRecognizer;
            public iOSPressedEffect()
            {
                _longPressRecognizer = new UILongPressGestureRecognizer(HandleLongClick);
            }
    
            protected override void OnAttached()
            {
                if (!_attached)
                {
                    if (Control != null)
                    {
                        Control.AddGestureRecognizer(_longPressRecognizer);
                        Control.UserInteractionEnabled = true;
                    }
                    else
                    {
                        Container.AddGestureRecognizer(_longPressRecognizer);
                    }               
                    _attached = true;
                }
            }
    
            private void HandleLongClick(UILongPressGestureRecognizer recognizer)
            {
                if (recognizer.State == UIGestureRecognizerState.Began)
                {
                    var command = PressedEffect.GetLongPressedCommand(Element);
                    command?.Execute(PressedEffect.GetLongParameter(Element));
                }
                else if (recognizer.State == UIGestureRecognizerState.Ended)
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
                        Control.RemoveGestureRecognizer(_longPressRecognizer);
                    }
                    else
                    {
                        Container.RemoveGestureRecognizer(_longPressRecognizer);
                    }
                    _attached = false;
                }
            }
        }
    }
