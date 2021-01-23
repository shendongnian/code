    var totalProperty = typeof(Report).GetProperty("Total");
    var value = emit.DeclareLocal<object>();
    //invoke TryGetValue on dictionary to populate local 'value'*
                                                        //stack: [bool returned-TryGetValue]
    //either Pop() or use in If/Else to consume value **
                                                        //stack: 
    //load the Report instance to the top of the stack 
    //(or create a new Report)
                                                        //stack: [report]
    emit.LoadLocal(value);                              //stack: [report] [object value]
    emit.UnboxAny(totalProperty.PropertyType);          //stack: [report] [decimal value]
    //setter has signature "void (this Report, decimal)" 
    //so it consumes two values off the stack and pushes nothing
    emit.CallVirtual(totalProperty.SetMethod);          //stack: 
 
