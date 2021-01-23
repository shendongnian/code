    using System;
    using System.Collections.ObjectModel;
    class MyClass<T> : Collection<T> {
        protected override void InsertItem(int index, T item) {
            base.InsertItem(index, item);
            Console.WriteLine("Added:" + item.ToString());
        }
        protected override void SetItem(int index, T item) {
            base.SetItem(index, item);
            Console.WriteLine("Set (indexer):" + item.ToString());
        }
        // see also ClearItems and RemoveItem
    }
