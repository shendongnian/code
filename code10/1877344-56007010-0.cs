// Non static so that you can access ListView1
public void GetHtmlAsync(string id, string seller, string product, string betTime, string price, string shipping, string link)
{
   GetHtmlAsync(listView1, id, seller, product, betTime, price, shipping, link);
}
// Static
public static async void GetHtmlAsync(ListView listView, string id, string seller, string product, string betTime, string price, string shipping, string link)
{
    string[] row = { id, seller, product, betTime, price + shipping, link };
    var listViewItem = new ListViewItem(row);
    listView.Items.Add(listViewItem);
}
