    public  int solution(int A) {
            var charArray=A.ToString().ToCharArray();
            StringBuilder sb=new StringBuilder();
    
            for(int i=0,j=charArray.Length-1; i<=j; i++,j--)
            {
                //Console.WriteLine(" ("+i+","+j+")");
                sb.Append(charArray[i]);
                if(i!=j)
                    sb.Append(charArray[j]);
                //Console.WriteLine(sb.ToString());
            }
        
        return (Int32.Parse(sb.ToString()));
    }
