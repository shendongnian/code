      public class ChangePropertyAction : TargetedTriggerAction<object>
      {
        /* some dependency properties here, like DurationProperty, ValueProperty, etc... */
    
    
        protected override void Invoke(object parameter)
        {
           /* a lot of validation here, but skimming over that mostly. Valid input results in a call to AnimatePropertyChange() */
        }
    
        private void AnimatePropertyChange(PropertyInfo propertyInfo, object fromValue, object newValue)
        {
          Storyboard storyboard = new Storyboard();
          Timeline timeline = !typeof (double).IsAssignableFrom(propertyInfo.PropertyType) 
    				? (!typeof (Color).IsAssignableFrom(propertyInfo.PropertyType)
    				? (!typeof (Point).IsAssignableFrom(propertyInfo.PropertyType)
    				? this.CreateKeyFrameAnimation(fromValue, newValue)
    					: this.CreatePointAnimation((Point) fromValue, (Point) newValue))
    					: this.CreateColorAnimation((Color) fromValue, (Color) newValue))
    					: this.CreateDoubleAnimation((double) fromValue, (double) newValue);
          timeline.Duration = this.Duration;
          storyboard.Children.Add(timeline);
          Storyboard.SetTarget((Timeline) storyboard, (DependencyObject) this.Target);
          Storyboard.SetTargetProperty((Timeline) storyboard, new PropertyPath(propertyInfo.Name, new object[0]));
          storyboard.Completed += (EventHandler) ((o, e) => propertyInfo.SetValue(this.Target, newValue, new object[0]));
          storyboard.FillBehavior = FillBehavior.Stop;
          storyboard.Begin();
        }
    
        private static object GetCurrentPropertyValue(object target, PropertyInfo propertyInfo)
        {
          FrameworkElement frameworkElement = target as FrameworkElement;
          target.GetType();
          object obj = propertyInfo.GetValue(target, (object[]) null);
          if (frameworkElement != null && (propertyInfo.Name == "Width" || propertyInfo.Name == "Height") && double.IsNaN((double) obj))
            obj = !(propertyInfo.Name == "Width") ? (object) frameworkElement.ActualHeight : (object) frameworkElement.ActualWidth;
          return obj;
        }
    
        private Timeline CreateDoubleAnimation(double fromValue, double newValue)
        {
          return (Timeline) new DoubleAnimation()
          {
            From = new double?(fromValue),
            To = new double?(newValue),
            EasingFunction = this.Ease
          };
        }
      }
