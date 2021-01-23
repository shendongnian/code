    public class VeryObservableCollection<T> : ObservableCollection<T>
    /// <summary>
    /// Override for setting item
    /// </summary>
    /// <param name="index">Index</param>
    /// <param name="item">Item</param>
    protected override void SetItem(int index, T item)
    {
        try
        {
            INotifyPropertyChanged propOld = Items[index] as INotifyPropertyChanged;
            if (propOld != null)
                propOld.PropertyChanged -= new PropertyChangedEventHandler(Affecting_PropertyChanged);
        }
        catch (Exception ex)
        {
            Exception ex2 = ex.InnerException;
        }
        INotifyPropertyChanged propNew = item as INotifyPropertyChanged;
        if (propNew != null)
            propNew.PropertyChanged += new PropertyChangedEventHandler(Affecting_PropertyChanged);
        base.SetItem(index, item);
    }
