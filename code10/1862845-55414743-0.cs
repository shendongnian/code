    public partial class Form1 : Form
        {
            // PERSONAL BING KEY
            String BingKey = "*******************************";
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                GetFind();
            }
    
            private async void GetFind()
            {    
                var request = new GeocodeRequest()
                {
                    Query = "Via trento 1, Sondrio",
                    IncludeIso2 = true,
                    IncludeNeighborhood = true,
                    MaxResults = 25,
                    BingMapsKey = BingKey
                };
    
    
                //Process the request by using the ServiceManager.
                var response = await request.Execute();
    
                if (response != null &&
                    response.ResourceSets != null &&
                    response.ResourceSets.Length > 0 &&
                    response.ResourceSets[0].Resources != null &&
                    response.ResourceSets[0].Resources.Length > 0)
                {
                    var result = response.ResourceSets[0].Resources[0] as Location;
    
                    var myAddr = result.Address.AddressLine;
                    var CAP = result.Address.PostalCode;
                    var City = result.Address.Locality;
                    var Province = result.Address.AdminDistrict2;
                    var Region = result.Address.AdminDistrict;
                    var Stato = result.Address.CountryRegion;
    
                    var coords = result.Point.Coordinates;
                    if (coords != null && coords.Length == 2)
                    {
                        var lat = coords[0];
                        var lng = coords[1];
    
                        string Latitude = String.Format("{0:00.000000}", lat);
                        string Longitude = String.Format("{0:000.000000}", lng);
    
                        txtResult.Text = "Indirizzo: " + myAddr +
                            Environment.NewLine + "CAP: " + CAP +
                            Environment.NewLine + "Città: " + City +
                            Environment.NewLine + "Provincia: " + Province +
                            Environment.NewLine + "Regione: " + Region +
                            Environment.NewLine + "Stato: " + Stato + 
                            Environment.NewLine + $"Coordinate - Lat: {Latitude} / Long: {Longitude}"
                            ;
                    }
                }
            } 
        }
    }
