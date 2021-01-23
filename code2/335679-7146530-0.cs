                int chipRowCount = theChipDGV.RowCount;
                int dataBaseRowCount = theDataBaseDGV.RowCount;
                for (int count = 0; count < chipRowCount; count++)
                {
                    for (int i = 0; i < dataBaseRowCount; i++)
                    {
                        if (theChipList[count].PkgStyle.Equals(theDataBaseList[i].PackageType) || (theChipList[count].PkgStyle.Contains(theDataBaseList[i].PackageType) &&
                            theDataBaseList[i].PartDescription.Contains("R") && theChipList[count].Name.StartsWith("R")) || ((theChipList[count].PkgStyle.Contains(theDataBaseList[i].PackageType) &&
                            theDataBaseList[i].PartDescription.Contains("C") && theChipList[count].Name.StartsWith("C"))))
                        {
                            if (!theChipList[count].Used)
                            {
                                theChipList[count].Used = true;
                                theFinalList.Add(new LoadLine(theChipList[count].Name, theChipList[count].PartNumber,
                                    theChipList[count].XPlacement, theChipList[count].YPlacement, theChipList[count].Rotation,
                                    theChipList[count].PkgStyle, theDataBaseList[i].PackageType, theDataBaseList[i].PartDescription,
                                    theDataBaseList[i].Feeder, theDataBaseList[i].Vision, theDataBaseList[i].Speed,
                                    theDataBaseList[i].Machine, theDataBaseList[i].TapeWidth, 0));
                                theFinalDGV.DataSource = theFinalList;
                            }
                        }
                    }
                }
                for (int count = 0; count < theChipList.Count; count++)
                {
                    if (!theChipList[count].Used)
                    {
                        theFinalList.Add(new LoadLine(theChipList[count].Name, theChipList[count].PartNumber,
                            theChipList[count].XPlacement, theChipList[count].YPlacement, theChipList[count].Rotation,
                            theChipList[count].PkgStyle, string.Empty, string.Empty, string.Empty, string.Empty,
                            string.Empty, string.Empty, string.Empty, 0));
                    }
                }
