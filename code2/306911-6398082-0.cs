      class BindLastAncestor : MarkupExtension
      {
        public BindLastAncestor()
        {
        }
    
        public BindLastAncestor( Type ancestorType )
        {
        }
    
        public Type AncestorType
        {
          get;
          set;
        }
    
        public PropertyPath Path
        {
          get;
          set;
        }
    
        public override object ProvideValue( IServiceProvider serviceProvider )
        {
          var targetProvider = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
    
          var target = targetProvider.TargetObject as DependencyObject;
          var targetProperty = targetProvider.TargetProperty as DependencyProperty;
          if (target == null || targetProvider == null)
            throw new NotSupportedException();
    
          var ancestor = target;
          DependencyObject lastAncestor = null;
    
          while (ancestor != null)
          {
            if (ancestor.GetType() == this.AncestorType)
              lastAncestor = ancestor;
    
            ancestor = VisualTreeHelper.GetParent(ancestor);
          }
    
          BindingOperations.SetBinding(target, targetProperty, new Binding { Path = this.Path, Source = lastAncestor });
    
          return target.GetValue(targetProperty);
        }
      }
