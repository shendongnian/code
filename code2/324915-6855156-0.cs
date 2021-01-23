    displayRev("bla");
    displayRev("la");
    displayRev("a");
    //Now it gets an error
    //The string.Length "a" is bigger than 0 (it´s 1)
    //in displayRev(str.Substring(1, str.Length-1)); he wants to make a SubString beginning at the
    //index 1 (the Second character), but the string contains only 1 character 
    //if-Statement have to look like:
    if(str.Length > 1)  
          displayRev(str.Substring(1, str.Length-1)); 
        else  
          return; 
