    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xamarin.Forms;
    
    namespace MyApp.CustomControls
    {
        public class CustomEditor : Editor
        {
            public static readonly BindableProperty PlainTextProperty =
                BindableProperty.Create(nameof(PlainText),
                    typeof(string),
                    typeof(CustomEditor),
                    String.Empty,
                    defaultBindingMode:BindingMode.TwoWay,
                    propertyChanged:OnPlainTextChanged);
    
            public string PlainText {
                get { return (string)GetValue(PlainTextProperty); }
                set { SetValue(PlainTextProperty, value); }
            }
    
            private static void OnPlainTextChanged(BindableObject bindable, object oldValue, object newValue)
            {
                var control = (CustomEditor)bindable;
                if (newValue != null)
                {
                    control.PlainText = newValue.ToString();
                }
            }
        }
    }
