    int index = -1;
    for (int i = 0; i < collection.Count; i++)
    {
       var lbi = listBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem;
       if (lbi == null) continue;
       if (IsMouseOverTarget(lbi, e.GetPosition((IInputElement)lbi)))
       {
           index = i;
           break;
       }
    }
