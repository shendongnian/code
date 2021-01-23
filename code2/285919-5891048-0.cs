    StringBuilder sb = new StringBuilder();
    for(int i =0; i< status.Length; i++)
    {
       if(status[i]){
       sb.Append('A' + (char)i);
    }
    
    string result = sb.ToString();
