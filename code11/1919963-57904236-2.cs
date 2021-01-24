    void OnBindingContextChanged(object sender, EventArgs e)
    {
        OnBindingContextChanged();
        var visualElement = sender as VisualElement;
        if (visualElement == null)
        {
            return;
        }
        if (visualElement.BindingContext == null)
        {
            OnDetachingFrom(visualElement);
        }
    }
