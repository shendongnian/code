    public static string ConvertToBinary(ulong value){
      if(value==0)return "0";
      System.Text.StringBuilder b=new System.Text.StringBuilder();
      while(value!=0){
        b.Insert(0,((value&1)==1) ? '1' : '0');
        value>>=1;
      }
      return b.ToString();
    }
