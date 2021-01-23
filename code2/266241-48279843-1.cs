    //Without Extension Methods Like: Split, ToCharArray, etc..
    
    public string ReverseString(string str="Hai How Are You?"){
        var FullRev="", 
        var wordRev="";
        for(i=0;i<=str.length;i++){
            if(str[i]==" " || i==str.length){
                FullRev=FullRev+" "+wordRev; //FullRev=wordRev+" "+FullRev; 
                wordRev="";
            }else{
                wordRev=str[i]+wordRev;
            }
        }
        return FullRev;
    } 
    //Result "iaH woH erA ?uoY"
