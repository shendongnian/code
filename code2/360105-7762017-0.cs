    ArrayList RemoveList = new ArrayList();
    foreach (PC_list x in onlinelist)
                {
                    if ((nowtime.Subtract(x.time)).TotalSeconds > 5)
                    {
                        Invoke(new MethodInvoker(delegate
                        {
                            index = Main_ListBox.FindString(x.PcName);
                            if(index != ListBox.NoMatches)
                                Main_ListBox.Items.RemoveAt(index);
                        }));
    
                        RemoveList.Add(x);
                        //Thread.Sleep(500);
                    }
                }
    foreach (PC_list x in RemoveList)
            {
                    onlinelist.Remove(x);
            }
