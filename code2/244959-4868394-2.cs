    public class Set: List<float>
    {
        public Set():base(){}
    
        public static Set operator+(Set set1, Set set2)
        {
            Set result = new Set();
            result.AddRange(set1.ToArray());
            result.AddRange(set2.ToArray());
            return result;
        }
    
        public float Sum
        {
            get
            {
                if( this.Count == 0 )
                    return 0F;
                
                return this.Sum();
                
            }
        }
    
        public override string ToString()
        {
            string formatString = string.Empty;
            string result = string.Empty;
         
            for(int i=0; i<this.Count; i++)
            {
                formatString += "{" + i.ToString() + "} + ";
            }
    
            formatString = result.TrimEnd((" +").ToCharArray()); // remove the last "+ ";
    
            float[] values = this.ToArray();
       
            result = String.Format(formatString, values);
    
            return String.Format("{0} = {1}", result, this.Sum);
    
        }
    }
