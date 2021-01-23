<pre>
foreach (PropertyInfo pi in dt.GetType().GetProperties())
        {
            if(pi.PropertyType == typeof(DateTime?))
            {
               // display nullable info
            }
        }
</pre>
