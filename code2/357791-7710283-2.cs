    class MyForm : Form
    {
        ...
        void BindDGV()
        {
            dataGridView1.Columns["myColumnName"].DataPropertyName = "MyProp";
            dataGridView1.DataSource = MyBindingList<MyDataObject>(...);
        }
    }
