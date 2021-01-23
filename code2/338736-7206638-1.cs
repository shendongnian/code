    // on the main thread
    
    // la la la doing work
    // wait 500ms
    var tmr=new Timer{Interval=500};
    tmr.Tick+=(s,e)=>{/*action .5sec later*/ btn.Enabled=false; tmr.Enabled=false;};
    tmr.Enabled=true;
    
    // and quit
    return;
