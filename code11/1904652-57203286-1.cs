public override string ToString()
{
    return this.NameFirst + ' ' + this.NameLast;
}
**Side note**
I use a wrapper access around listboxes or comboboxes like so for easier type-safe access.
I flesh out the interfaces as needed and fallback to direct access where strong doesn't necessarily make things any simpler.
      public class ListBoxT<T>
        {
            readonly ListBox _lb;
            public T SelectedItem { get => (T)_lb.SelectedItem; set => _lb.SelectedItem = value; }
            public void AddItem(T item) => _lb.Items.Add(item);
            public ListBoxT(ListBox lb) => this._lb = lb;
    
        }
    
        public class ComboBoxT<T>
        {
            readonly ComboBox _cb;
    
            public ComboBoxT(ComboBox cb) => this._cb = cb;
    
            public T SelectedItem { get => (T)_cb.SelectedItem; set => _cb.SelectedItem = value; }
            public Rectangle Bounds => this._cb.Bounds;
            public int Count => this._cb.Items.Count;
            public IReadOnlyCollection<T> Items { get => new ReadOnlyCollection<T>(_cb.Items.Cast<T>().ToList()); }
            public void BeginUpdate() => _cb.BeginUpdate();
            public void Clear() => _cb.Items.Clear();
            public void AddRange(IEnumerable<T> items)
            {
                _cb.SuspendLayout();
                _cb.Items.AddRange(items.Cast<object>().ToArray());
                _cb.ResumeLayout();
            }
            public void EndUpdate() => _cb.EndUpdate();
            public bool Enabled { get => _cb.Enabled; set => _cb.Enabled = value; }
            public int SelectedIndex { get => _cb.SelectedIndex; set => _cb.SelectedIndex = value; }
            public ComboBox Value => _cb;
            public T this[int x]
            {
                get => (T)this._cb.Items[x];
                set => this._cb.Items[x] = value;
            }
        }
