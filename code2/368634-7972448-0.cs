    for(int i = _workList.Count(); _workList.Count()> 0; i--){
       w = _workList[i];
       res = DoSomethingOnWork(w);
       if(res) {
           _workList.Remove(w);
       }
       // Handle reseting i once we've looped through entire list
       if(i == 0){
           i = _workList.Count() - 1;
       }
    }
