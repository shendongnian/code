    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    public class ObservableBindingList<T> : ObservableCollection<T>, IBindingList
    {
        //  Constructors
        public ObservableBindingList() : base()
    	{
    	}
    
        public ObservableBindingList(IEnumerable<T> collection) : base(collection)
    	{
    	}
    
        public ObservableBindingList(List<T> list) : base(list)
    	{
    	}
    
        //  IBindingList Implementation
        public void AddIndex(PropertyDescriptor property)
        {
            throw new NotImplementedException();
        }
    
        public object AddNew()
        {
            throw new NotImplementedException();
        }
    
        public bool AllowEdit
        {
            get { throw new NotImplementedException(); }
        }
    
        public bool AllowNew
        {
            get { throw new NotImplementedException(); }
        }
    
        public bool AllowRemove
        {
            get { throw new NotImplementedException(); }
        }
    
        public void ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            throw new NotImplementedException();
        }
    
        public int Find(PropertyDescriptor property, object key)
        {
            throw new NotImplementedException();
        }
    
        public bool IsSorted
        {
            get { throw new NotImplementedException(); }
        }
    
        public event ListChangedEventHandler ListChanged;
    
        public void RemoveIndex(PropertyDescriptor property)
        {
            throw new NotImplementedException();
        }
    
        public void RemoveSort()
        {
            throw new NotImplementedException();
        }
    
        public ListSortDirection SortDirection
        {
            get { throw new NotImplementedException(); }
        }
    
        public PropertyDescriptor SortProperty
        {
            get { throw new NotImplementedException(); }
        }
    
        public bool SupportsChangeNotification
        {
            get { throw new NotImplementedException(); }
        }
    
        public bool SupportsSearching
        {
            get { throw new NotImplementedException(); }
        }
    
        public bool SupportsSorting
        {
            get { throw new NotImplementedException(); }
        }
    }
