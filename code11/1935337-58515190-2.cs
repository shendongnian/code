for (int i = 0; i < lb1.Items.Count; i++)
{
    if (lb1.Items[i].ToString().EndsWith(search))
    {
        int indx = lb1.Items[i].ToString().LastIndexOf(search);
        string item = lb1.Items[i].ToString().Substring(0, indx) + replace;
        lb1.Items[i] = item;
    }
}
**Solution 2:**
If all of your list items are comma separated strings like the image above, then you could do:
for (int i = 0; i < lb1.Items.Count; i++)
{
    if (lb1.Items[i].ToString().EndsWith(search))
    {
        var arr = lb1.Items[i].ToString().Split(',');
        arr[arr.Length - 1] = replace;
        lb1.Items[i] = string.Join(", ", arr);
    }
}
Sorry for any inconvenience mikee.
Good luck.
