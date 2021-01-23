    Observable.FromEvent
        <DependencyPropertyChangedEventHandler, DependencyPropertyChangedEventArgs>
        (a => new DependencyPropertyChangedEventHandler(
            new Action<object, DependencyPropertyChangedEventArgs>((s, e) => a(e))),
            h => this.DataContextChanged += h, h => this.DataContextChanged -= h)
            .Subscribe(e => MessageBox.Show(e.NewValue.ToString()));
