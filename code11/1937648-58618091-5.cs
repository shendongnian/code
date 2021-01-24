    using System;
    using Xamarin.Forms;
    namespace YourNameSpace
    {
        public class GradientView : BoxView
        {
            public static readonly BindableProperty StartColorProperty =
                BindableProperty.Create(
                    nameof(StartColor),
                    typeof(Color),
                    typeof(GradientView),
                    Color.Transparent);
        
            public Color StartColor
            {
                get
                {
                    return (Color)GetValue(StartColorProperty);
                }
                set
                {
                    SetValue(StartColorProperty, value);
                }
            }
            public static readonly BindableProperty MiddleColorProperty =
                BindableProperty.Create(
                    nameof(MiddleColor),
                    typeof(Color),
                    typeof(GradientView),
                    Color.Transparent);
            public Color MiddleColor
            {
                get
                {
                    return (Color)GetValue(MiddleColorProperty);
                }
                set
                {
                    SetValue(MiddleColorProperty, value);
                }
            }
            public static readonly BindableProperty EndColorProperty =
                BindableProperty.Create(
                    nameof(EndColor),
                    typeof(Color),
                    typeof(GradientView),
                    Color.Transparent);
            public Color EndColor
            {
                get
                {
                    return (Color)GetValue(EndColorProperty);
                }
                set
                {
                    SetValue(EndColorProperty, value);
                }
            }
        }
    }
