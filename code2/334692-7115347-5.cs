    var Select = from Table2 in dc.GetTable<table2>()                             
                             //Right Join                                                      
                             from Table3_3 in dc.GetTable<table3>()
                             .Where(item => item.StID == Table2.StID)
                             .Select(item => item)                             
                             //Inner Join From Right Join                                                                                       
                             join Table1_3_1 in dc.GetTable<table1>()                                 
                                on Table3_3.ECode equals Table1_3_1.SCode
                             //Left Join table4
                             join entityTable4 in dc.GetTable<table4>()
                                on Table3_3.TypeID equals entityTable4.TypeID into tempTable4
                             from Table4 in tempTable4.DefaultIfEmpty()
                             //Left Join table5
                             join entityTable5 in dc.GetTable<table5>()
                                on Table3_3.ValueID equals entityTable5.ValueId into tempTable5
                             from Table5 in tempTable5.DefaultIfEmpty()
                             //Left Join table2 (table6)
                             join entityTable2 in dc.GetTable<table2>()
                                on Table3_3.Num equals entityTable2.StID into tempTable2
                             from Table6 in tempTable2.DefaultIfEmpty()
                             //Left Join table5 (table7)
                             join entityTable5 in dc.GetTable<table5>()
                                on Table3_3.TValueID equals entityTable5.ValueId into tempTable5_7
                             from Table7 in tempTable5_7.DefaultIfEmpty()
                             //Filter
                             where Table2.Col1 == "1000"
                             select new
                             {  
                                 table1 = new { SCode = (string)Table1_3_1.SCode },
                                 table2 = new { StID = (int)Table2.StID, Col1 = (string)Table2.Col1 },
                                 table3 = new
                                 {
                                     StID = (int)Table3_3.StID,
                                     TypeID = (int)Table3_3.TypeID,
                                     ValueID = (int)Table3_3.ValueID,
                                     TValueID = (int)Table3_3.TValueID,
                                     Num = Table3_3.Num,
                                     ECode = Table3_3.ECode
                                 },
                                 table4 = Table4 == null ? null : new { TypeID = (int)Table4.TypeID },
                                 table5 = Table5 == null ? null : new { ValueID = (int)Table5.ValueId },
                                 table6 = Table6 == null ? null : new { StID = (int)Table6.StID, Col1 = (string)Table6.Col1 },
                                 table7 = Table7 == null ? null : new { ValueID = (int)Table7.ValueId }
                             };
