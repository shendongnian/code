protected override void OnColumnDisplayIndexChanged(DataGridColumnEventArgs e)
        {
            if (ignoreReorder)
            {
                return;
            }
            base.OnColumnDisplayIndexChanged(e);           
            storeColumnMovedPositions(e.Column);
            if (hasColumnOrderingEnded())
            {
                newOrder.Clear();
                foreach (DataGridColumn column in this.Columns)
                {
                    newOrder.Add(column.DisplayIndex, column.Header.ToString());
                }
                   
                if (mListener != null)
                {
                    new Thread(() =>
                    {
                        Thread.Sleep(50);
                        System.Windows.Application.Current.Dispatcher.Invoke(new Action(() => {
                            mListener.OnReorderFinished(new List<string>(newOrder.Values));
                        }));                        
                    }).Start();
                }                
            }
        }
