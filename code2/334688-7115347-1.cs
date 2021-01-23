    var Select = from Table1 in dc.GetTable<table1>()
                             from Table2 in dc.GetTable<table2>()
                             from Table3 in dc.GetTable<table3>()
                             //Right Join                         
                             join Table3_3 in dc.GetTable<table3>()
                                on Table2.StID equals Table3_3.StID into right
                             //Inner Join From Right Join 
                             from Table1_3 in right
                             join Table1_3_1 in dc.GetTable<table1>()
                                on Table1_3.ECode equals Table1_3_1.SCode
                             //Left Join table4
                             join entityTable4 in dc.GetTable<table4>()
                                on Table3.TypeID equals entityTable4.TypeID into tempTable4
                             from Table4 in tempTable4.DefaultIfEmpty()
                             //Left Join table5
                             join entityTable5 in dc.GetTable<table5>()
                                on Table3.ValueID equals entityTable5.ValueId into tempTable5
                             from Table5 in tempTable5.DefaultIfEmpty()
                             //Left Join table2 (table6)
                             join entityTable2 in dc.GetTable<table2>()
                                on Table3.Num equals entityTable2.StID into tempTable2
                             from Table6 in tempTable2.DefaultIfEmpty()
                             //Left Join table5 (table7)
                             join entityTable5 in dc.GetTable<table5>()
                                on Table3.TValueID equals entityTable5.ValueId into tempTable5_7
                             from Table7 in tempTable5_7.DefaultIfEmpty()
                             //Filter
                             where Table2.Col1 == "1000"
                             select new
                             {
                                 Table1
                             };
