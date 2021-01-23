    using System;
    
    class Sample {
        static public void Main(){
            string s1 = "bc3231dsc";
            string s2 = "bc3462dsc";
            int len = 9;//s1.Length;//cond.1)
            int l_pos = 0;
            int r_pos = len;
            for(int i=0;i<len && Char.ToLower(s1[i])==Char.ToLower(s2[i]);++i){
                ++l_pos;
            }
            for(int i=len-1;i>0 && Char.ToLower(s1[i])==Char.ToLower(s2[i]);--i){
                --r_pos;
            }
            string leftMatch = s1.Substring(0,l_pos);
            string center1 = s1.Substring(l_pos, r_pos - l_pos);
            string center2 = s2.Substring(l_pos, r_pos - l_pos);
            string rightMatch = s1.Substring(r_pos);
            Console.Write(
            "leftMatch = \"{0}\"\n" +
            "center1 = \"{1}\"\n" +
            "center2 = \"{2}\"\n" +
            "rightMatch = \"{3}\"\n",leftMatch, center1, center2, rightMatch);
        }
    }
