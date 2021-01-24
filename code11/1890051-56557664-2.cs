    List<DepartmentDto> list = new List<DepartmentDto>();
    for (int i = 0; i<10; i++)
    {
        list.Add(new DepartmentDto { Checked = false, Afdeling_Txt = "item" + i });
    }
    
    DepartmentListAdapter customAdapter = new DepartmentListAdapter(this, list);
    Departmentlistview.Adapter = customAdapter;
