    class CanvasBehaviour : Behavior<Canvas>
        {
            protected override void OnAttached()
            {
                base.OnAttached();
                this.AssociatedObject.IsVisibleChanged += this.MyMethods;
            }
    
            private void MyMethods(object sender, DependencyPropertyChangedEventArgs e)
            {
                // Do what you want
            }
        }
