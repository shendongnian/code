    // veriables been used
    List<T> diffList = new List<T>();
    List<T> gotResultList = new List<T>();
     
    
       
    // compare First field within my MyList
    gotResultList = MyList1.Where(a => !MyList2.Any(a1 => a1.MyListTField1 == a.MyListTField1)).ToList().Except(gotResultList.Where(a => !MyList2.Any(a1 => a1.MyListTField1 == a.MyListTField1))).ToList();
    // Generate result list
    diffList.AddRange(gotResultList);
    
    // compare Second field within my MyList
    gotResultList = MyList1.Where(a => !MyList2.Any(a1 => a1.MyListTField2 == a.MyListTField2)).ToList().Except(gotResultList.Where(a => !MyList2.Any(a1 => a1.MyListTField2 == a.MyListTField2))).ToList();
    // Generate result list
    diffList.AddRange(gotResultList);
    
    
    MessageBox.Show(diffList.Count.ToString);
