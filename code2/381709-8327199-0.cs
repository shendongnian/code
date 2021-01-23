    public static string Inc(string s){
        System.Func<char,int> v = c => (int)((c<='9')?(c-'0'):(c-'A'+10));
        System.Func<int,char> ch = d => (char)(d+((d<10)?'0':('A'-10)));    
        s = s.ToUpper();    
        var sb = new System.Text.StringBuilder(s.Length);
        sb.Length = s.Length;
        int carry = 1;
        for(int i=s.Length-1; i>=0; i--){
            int x = v(s[i])+carry;    
            carry = x/36;
            sb[i] = ch(x%36);
        }
        if (carry>0)
            return ch(carry) + sb.ToString();
        else
            return sb.ToString();
    }
