        public IDictionary<string, object> ProcessJson(IDictionary<string, object> inputDic, LoansLogData loandata, string itemno, string parentKey = "", string childKey = "", int cnt = 1)
        {
            dynamic flexible = new ExpandoObject();
            IDictionary<string, object> ResultDic = (IDictionary<string, object>)flexible;
            try
            {
                foreach (KeyValuePair<string, object> entry in inputDic)
                {
                    List<string> ElementCollection = new List<string>();
                    List<string> _lstValue = new List<string>();
                    if (entry.Value is System.Collections.ICollection)
                    {
                        var countProp = entry.Value.GetType().GetProperty("Count");
                        var count = (int)countProp.GetValue(entry.Value, null);
                        int loopcount = 0;
                        foreach (var item in (System.Collections.ICollection)entry.Value)
                        {
                            if (item is Dictionary<string, object>)
                            {
                                if (entry.Key != null && entry.Key.Trim().StartsWith("@"))
                                {
                                    parentKey = entry.Key.Trim();
                                    parentKey = parentKey.Substring(0, parentKey.IndexOf(' '));
                                    childKey = entry.Key.Trim().Replace(parentKey, "");
                                    childKey = childKey.Trim();
                                }
                                if (parentKey == "@Loans")
                                {
                                    List<IDictionary<string, object>> catList = new List<IDictionary<string, object>>();
                                    foreach (var singleBibItem in loandata.ItemNo)
                                    {
                                        catList.Add(ProcessJson((Dictionary<string, object>)item, loandata, singleBibItem, parentKey, childKey, cnt));
                                        cnt++;
                                    }
                                    ResultDic.Add(childKey, catList);
                                }
                                else
                                {
                                    List<IDictionary<string, object>> BorrowList = new List<IDictionary<string, object>>();
                                    BorrowList.Add(ProcessJson((Dictionary<string, object>)item, loandata, itemno, parentKey, childKey));
                                    ResultDic.Add(childKey, BorrowList);
                                }
                            }
                            else
                            {
                                List<string> ResString = ReturnLoanConciseValEntry(parentKey, (String)item, itemno, loandata, cnt);
                                if (ResString.Count > 0)
                                {
                                    _lstValue.AddRange(ResString);
                                }
                                if (_lstValue.Count > 0)
                                {
                                    if (((String)item == "LoansItemBib" || (String)item == "LoansItemNo"))
                                        _lstValue = _lstValue.Distinct().ToList();
                                    loopcount += 1;
                                    if (loopcount == count)
                                        ResultDic.Add(entry.Key, _lstValue);
                                }
                            }
                        }
                    }
                }
                return ResultDic;
            }
            catch (Exception ex)
            {
                return ResultDic;
            }
        }
