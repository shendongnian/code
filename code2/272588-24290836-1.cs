    Be.Timvw.Framework.ComponentModel.SortableBindingList x1;                       // 1
    x1 = new Be.Timvw.Framework.ComponentModel.SortableBindingList<sourceObject>(); // 2
    BindingSource bsx1 = new BindingSource();
    bsx1.DataSource = x1;
    dataGridView1.DataSource = bsx1;
