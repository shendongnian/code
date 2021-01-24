MyCotDataList.Add(new COTData_Obj
{
    Min = last26CnValues.Min(),
    Max = last26CnValues.Max(),
}
You should set it to the object already in the list. I guess this should work
COTData_Obj row = new COTData_Obj
                {
                    Time =  DateTime.Parse(split[0]), 
                    CN = double.Parse(split[5]) - double.Parse(split[6]),
                };
MyCotDataList.Add(row); 
                var last26CnValues = MyCotDataList
                    .AsEnumerable()
                        .Reverse()
                        .Take(26)
                          .Select(x => x.CN)
                        .ToArray();
                row.Min = last26CnValues.Min();
                row.Max = last26CnValues.Max();
