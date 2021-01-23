public List&lt;decimal&gt; addTwo(List&lt;decimal&gt; mark)
{
   List&lt;decimal&gt; temp = mark;
   for (int i = 0; i &lt; temp.Count; i++)
   {
       temp[i] += 2m;
   }
   return temp;
}
