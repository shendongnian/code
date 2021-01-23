                        DateTime tempDate = dtList[i].Item1.Date;
                        var selectDates = dtList.FindAll(x => x.Item1.Date == tempDate.Date);
                        selectDates.Sort((a, b) => a.Item1.CompareTo(b.Item1));
                        dtFilteredList.Add(Tuple.Create(selectDates[0].Item1, selectDates[0].Item2));
                        dtList.RemoveAll(x => x.Item1.Date == tempDate.Date);
                        i = dtList.Count - 1;
                    }
