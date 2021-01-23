    public string ReverseString(string str="Hai How Are You?"){
        var FullRev="", 
        var wordRev="";
        for(i=0;i<=str.length;i++){
            if(str[i]==" " || i==str.length){
                FullRev=FullRev+" "+wordRev; 
                wordRev="";
            }else{
                wordRev=str[i]+wordRev;
            }
        }
        return FullRev.Trim();
    } 
    //Result "iaH woH erA ?uoY"
