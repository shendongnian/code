    Counter_class  XClass = new Counter_class();                
    FirebaseResponse firebaseResponse = await client.GetAsync("Counter/node");
    string JsTxt = response.Body;
                    if (JsTxt == "null")
                    {
                       
                        return ;
                    }
    
     dynamic data = JsonConvert.DeserializeObject<dynamic>(JsTxt);
                    var list = new List<XClass >();
                    foreach (var itemDynamic in data)
                    {
                      list.Add(JsonConvert.DeserializeObject<XClass > 
                      (((JProperty)itemDynamic).Value.ToString()));
                    }
                 // Now you have a list  you can loop through to put it at any suitable Visual  
                //control 
                    foreach ( XClass  _Xcls in list)
                    {
    Invoke((MethodInvoker)delegate {
                                DataGridViewRow row(DataGridViewRow)dg.Rows[0].Clone();
                                row.Cells[0].Value =_Xdcls...
                                row.Cells[1].Value =Xdcls...
                                row.Cells[2].Value =Xdcls...
                                ......
                                dg.Insert(0, row); 
                       
    }
