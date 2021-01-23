    03.411	v1 = dtbl.AsEnumerable().OrderBy("T30y, Dat desc").AsDataView();
    02.561	v2 = dtbl.AsEnumerable().OrderBy(dtbl, "T30y, Dat desc").AsDataView();
    01.573	v3 = dtbl.AsEnumerable().OrderBy(y=>y.Field<decimal>("T30y"))
                                    .ThenByDescending(y=>y.Field<DateTime>("Dat")).AsDataView();
    00.214	v4 = new DataView(dtbl, "", "T30y, Dat desc", DataViewRowState.CurrentRows);
    02.403	v1: 100,000 iterations of Find()
    01.708	v2: 100,000 iterations of Find()
    01.173	v3: 100,000 iterations of Find()
    00.261	v4: 100,000 iterations of Find()
