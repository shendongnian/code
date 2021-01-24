    using System;
    using Xamarin.Forms;
    namespace Sample.Utils
    {
        /// <summary>
        /// Allows setting Top,Left,Right,Bottom Margin independently from each other.
        /// The default implementation does not allow that, even from code. This
        /// attached property remembers the previously set margins and only modifies what you intend to modify.
        /// </summary>
        public static class Margin
        {
            public static readonly BindableProperty LeftProperty = BindableProperty.CreateAttached(
                propertyName: "Left",
                returnType: typeof(double),
                declaringType: typeof(Margin),
                propertyChanged: LeftPropertyChanged,
                defaultValue: 0.0d);
    
            private static void LeftPropertyChanged(BindableObject bindable, object oldValue, object newValue)
            {
                SetLeft(bindable, (double)newValue);
            }
    
            public static void SetLeft(BindableObject element, double value)
            {
                var view = element as View;
                if (view != null)
                {
                    Thickness currentMargin = (Xamarin.Forms.Thickness)view.GetValue(View.MarginProperty);
    
                    view.Margin = new Thickness(value, currentMargin.Top, currentMargin.Right, currentMargin.Bottom);
                }
            }
    
            public static double GetLeft(BindableObject element)
            {
                View view = element as View;
                if (view != null)
                {
                    Thickness margin = (Xamarin.Forms.Thickness)view.GetValue(View.MarginProperty);
                    return margin.Left;
                }
                return (double)LeftProperty.DefaultValue;
            }
    
        }
    }
