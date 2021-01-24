    private void _anotherThread_DoWork(object sender, DoWorkEventArgs e)
    {
        using(testdbEntities context = new testdbEntities())
        {
            _item = new item();
            this.txbItemName.Dispatcher.Invoke(new Action(delegate () { _item.name = this.txbItemName.Text; }));
            context.item.Add(_item);
            Application.Current.Dispatcher.BeginInvoke(new Action(() => this.ocItems.Add(_item)));
            context.SaveChanges();
            context.Detach(_item); 
        }
    }
