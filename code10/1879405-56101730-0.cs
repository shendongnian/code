public class Address
{
    [Text(Name = "SN")]
    public string SN { get; set; }
    [Text(Name = "JLN")]
    public string JLN { get; set; }
}
protected void BtnSearch_Clicked(object sender, EventArgs e)
{
    string SearchValue = txtSearchValue.Text;
    string es_host = System.Configuration.ConfigurationManager.AppSettings["cnStringIP"];
    string es_port = System.Configuration.ConfigurationManager.AppSettings["cnStringPort"];
    string es_index = System.Configuration.ConfigurationManager.AppSettings["cnStringIndex"];
    var settings = new ConnectionSettings(new Uri("http://" + es_host + ":" + es_port + ""))
        .DefaultIndex("masterlist*");
    var client = new ElasticClient(settings);
    var searchResponse = client.Search<Address>(s => s
            .From(0)
            .Size(100)
            .Query(q => q
                 .QueryString(qs => qs
                    .Query("JLN:\"" + SearchValue + "\"")
                )
            )
        );
    var address = searchResponse.Documents.ToList();
    ESGridview.DataSource = address;
    ESGridview.DataBind();
}
