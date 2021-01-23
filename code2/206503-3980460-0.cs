    int MaxLength = 20;
    private string Pad(string val){
       if(val.Length < 20){
          val = new String('0', MaxLength - val.Length) + val;
       }
       return val;
    }
    public bool IsBetween(string num, string start, string end){
        num = Pad(num);
        start = Pad(num);
        end = Pad(num);
        return String.Compare(num,start)>=0 && String.Compare(num,end)<=0;
    }
