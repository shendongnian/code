template &lt;typename T, typename Selector&gt;
double average(const vector&lt;T&gt;& items, Selector selector)
{
    double average= 0.0;
    for (int i = 0; i &lt; items.size(); i++)
    {
        average += selector(items[i]);
    }
    return average / items.size();
}
