    using System;
    using System.Windows;
    using System.ComponentModel;
    namespace WpfApplication1
    {
      public static class ValueTracker
      {
        // Attached dependency property for DefaultValue 
        public static object GetDefaultValue(DependencyObject obj)
        {
          return (object)obj.GetValue(DefaultValueProperty);
        }
        public static void SetDefaultValue(DependencyObject obj, object value)
        {
          obj.SetValue(DefaultValueProperty, value);
        }
        public static readonly DependencyProperty DefaultValueProperty =
            DependencyProperty.RegisterAttached("DefaultValue", 
            typeof(object), typeof(ValueTracker), new UIPropertyMetadata(0));
        // Attached dependency property for IsDefaultValue 
        public static bool GetIsDefaultValue(DependencyObject obj)
        {      
          return (bool)obj.GetValue(IsDefaultValueProperty);
        }
        private static void SetIsDefaultValue(DependencyObject obj, bool value)
        {
          obj.SetValue(IsDefaultValueProperty, value);
        }
    
        public static readonly DependencyProperty IsDefaultValueProperty =
            DependencyProperty.RegisterAttached("IsDefaultValue", 
            typeof(bool), typeof(ValueTracker), new UIPropertyMetadata(false));
        // Attached dependency property for TrackedProperty 
        public static DependencyProperty GetTrackProperty(DependencyObject obj)
        {
          return (DependencyProperty)obj.GetValue(TrackPropertyProperty);
        }
        public static void SetTrackProperty(DependencyObject obj, DependencyProperty value)
        {      
          obj.SetValue(TrackPropertyProperty, value);
        }
    
        public static readonly DependencyProperty TrackPropertyProperty =
            DependencyProperty.RegisterAttached("TrackProperty", 
            typeof(DependencyProperty), typeof(ValueTracker), 
            new UIPropertyMetadata(TrackPropertyChanged));
        public static void TrackPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {   
          DependencyProperty oldProperty = e.OldValue as DependencyProperty;
          if (oldProperty != null)
          {
            DependencyPropertyDescriptor dpd = 
              DependencyPropertyDescriptor.FromProperty(oldProperty, typeof(UIElement));
            if (dpd != null)
            {
              dpd.RemoveValueChanged(d, TrackedPropertyValueChanged);
            }
          }
          DependencyProperty newProperty = e.NewValue as DependencyProperty;
          if (newProperty != null)
          {        
            DependencyPropertyDescriptor dpd = 
              DependencyPropertyDescriptor.FromProperty(newProperty, typeof(UIElement));
            if (dpd != null)
            {
              dpd.AddValueChanged(d, TrackedPropertyValueChanged);
            }        
          }
        }
    
        private static void TrackedPropertyValueChanged(object sender, EventArgs e)
        {
          DependencyObject o = sender as DependencyObject;
          if (o != null)
          {         
            object defaultValue = Convert.ChangeType(GetDefaultValue(o), GetTrackProperty(o).PropertyType);
            SetIsDefaultValue(o, Object.Equals(o.GetValue(GetTrackProperty(o)), defaultValue));        
          }
        }
      }
    }
