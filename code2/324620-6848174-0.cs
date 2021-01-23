    int i=0;
    while(newline){
       if(patternMatch){
          // replace old values with new ones
          line.Replace(oldXList[i], newXList[i]).Replace(oldYList[i], newYList[i]);
          i++;
       }
    }
