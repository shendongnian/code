    using System;
    using System.Collections;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Windows.Data;
    using System.Windows.Threading;
    namespace StockCrawler
    {
	public class AutoRefreshListCollectionView : ListCollectionView
	{
		public AutoRefreshListCollectionView(IList list)
			: base(list)
		{
			this.SubscribeSourceEvents(list, false);
		}
		private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			bool refresh = false;
			foreach (SortDescription sort in this.SortDescriptions)
			{
				if (sort.PropertyName == e.PropertyName)
				{
					refresh = true;
					break;
				}
			}
			if (!refresh)
			{
				foreach (GroupDescription group in this.GroupDescriptions)
				{
					PropertyGroupDescription propertyGroup = group as PropertyGroupDescription;
					if (propertyGroup != null && propertyGroup.PropertyName == e.PropertyName)
					{
						refresh = true;
						break;
					}
				}
			}
			if (refresh)
			{
				if (!this.Dispatcher.CheckAccess())
				{
					// Invoke handler in the target dispatcher's thread
					this.Dispatcher.Invoke((Action)this.Refresh); 
				}
				else // Execute handler as is
				{
					this.Refresh();					
				}
			}
		}
		private void Source_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				this.SubscribeItemsEvents(e.NewItems, false);
			}
			else if (e.Action == NotifyCollectionChangedAction.Remove)
			{
				this.SubscribeItemsEvents(e.OldItems, true);
			}
			else
			{
				// TODO: Support this
			}
		}
		private void SubscribeItemEvents(object item, bool remove)
		{
			INotifyPropertyChanged notify = item as INotifyPropertyChanged;
			if (notify != null)
			{
				if (remove)
				{
					notify.PropertyChanged -= this.Item_PropertyChanged;
				}
				else
				{
					notify.PropertyChanged += this.Item_PropertyChanged;
				}
			}
		}
		private void SubscribeItemsEvents(IEnumerable items, bool remove)
		{
			foreach (object item in items)
			{
				this.SubscribeItemEvents(item, remove);
			}
		}
		private void SubscribeSourceEvents(object source, bool remove)
		{
			INotifyCollectionChanged notify = source as INotifyCollectionChanged;
			if (notify != null)
			{
				if (remove)
				{
					notify.CollectionChanged -= this.Source_CollectionChanged;
				}
				else
				{
					notify.CollectionChanged += this.Source_CollectionChanged;
				}
			}
			this.SubscribeItemsEvents((IEnumerable)source, remove);
		}
	}
    }
