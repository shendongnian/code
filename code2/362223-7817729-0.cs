    var items = mainDiagram.Elements
                    .Where(el => el.SubType == EElemSubType.BusBar
                        && connPts.Busbars.ContainsKey(el.ConnectionPointId));
    
                items.ForEach(item =>
                    {
                        if (!taAddrList.TAAddressList.ContainsKey(item.Key))
                        {
                            taAddrList.TAAddressList.Add(item.Key, new TAAddress());
                        }
                    });
