    public TreeView thistreeviewsucks;
    void SomeThread()
    {
         TreeView tv = new TreeView();
         tv.Items.Add("something");
         //upon completion
         this.thistreeviewsucks = InvokeTreeView(tv);
    }
