    public class Criteria 
    {
       StringBuilder sb = new StringBuilder();
       bool first;
       public void And(string property, string dbOperator, string value) {
           if (first)
           {
               sb.Append(" ").Append(property).Append(" ");
               sb.Append(" ").Append(dbOperator).Append(" ");
               sb.Append(" ").Append(value).Append(" ");
               first = true;
           }
           else
           {
               sb.Append(" && ").Append(property).Append(" ");
               sb.Append(" ").Append(dbOperator).Append(" ");
               sb.Append(" ").Append(value).Append(" ");
           }
       }
       public void Or(string property, string dbOperator, string value)
       {
           if (first)
           {
               sb.Append(" ").Append(property).Append(" ");
               sb.Append(" ").Append(dbOperator).Append(" ");
               sb.Append(" ").Append(value).Append(" ");
               first = true;
           }
           else
           {
               sb.Append(" || ").Append(property).Append(" ");
               sb.Append(" ").Append(dbOperator).Append(" ");
               sb.Append(" ").Append(value).Append(" ");
           }
       }
       public string ToString() 
       {
           return sb.ToString();
       }
       
    }
