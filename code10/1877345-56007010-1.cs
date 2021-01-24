c#
private void button1_Click(object sender, EventArgs e)
{
    keyword();
}
// Non static so that you can access ListView1
public void keyword()
{
    string country = "";
    string key = "1070";
    //Goto GetHtmlAsync
    GetHtmlAsync(key, country);
}
// Non static
public async void GetHtmlAsync(string key, string country)
{
    //GetHtmlAsync
    var url = "https://www.test.com/search?county=" + country + "&q=" + key;
    var httpClient = new HttpClient();
    var html = await httpClient.GetStringAsync(url);
    var htmlDocument = new HtmlDocument();
    htmlDocument.LoadHtml(html);
    //This is grabbed from HtmlDocument (list)
    var id = "58756";
    var seller = "Test";
    var product = "GTX 1070";
    var betTime = "10:10";
    var price = "100";
    var shipping = "4";
    string[] row = { id, seller, product, betTime, price + shipping, url };
    var listViewItem = new ListViewItem(row);
    listView1.Items.Add(listViewItem);
}
