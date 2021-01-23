public void AddSomethingToDatabase(Dictionary&lt;string, object&gt; parameters)
{
   foreach(KeyValuePair&lt;string, object&gt; param in parameters)
   {
      string paramname = param.Key;
      object paramvalue= param.Value;
      sp.AddParameter(paramname, paramvalue);
   }
   conn.Execute(...);
}
