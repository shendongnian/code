    public BindingSource MyDataGridViewDataSource
    {
       get 
       {
          return MyDataGridView.DataSource; // or you can skip 'get' if you don't need it
       }
       set
       {
          MyDataGridView.DataSource = value;
       }
    }
