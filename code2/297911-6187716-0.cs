    private void SavePoiRequest(MyPushpin pin)
        {
            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/x-www-form-urlencoded";
            wc.Encoding = Encoding.UTF8;
            wc.UploadStringCompleted += new UploadStringCompletedEventHandler((sender, e) =>
            {
                if (e.Error != null)
                {
                    return;
                }
                lastID = int.Parse(e.Result);
            });
            Uri baseAddressUri = new Uri("http://localhost:80/");
            UriTemplate uriTemplate = new UriTemplate("createpoi?name={name}&lat={latitude}&lng={longitude}&adr={address}&desc={photodesc}&story={poistory}");
            
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("name", pin.Name);
            parameters.Add("latitude", pin.Location.Latitude.ToString().Replace(",", "."));
            parameters.Add("longitude", pin.Location.Longitude.ToString().Replace(",", "."));
            parameters.Add("address", pin.Address);
            parameters.Add("photodesc", pin.PhotoDesc);
            parameters.Add("poistory", pin.Tag.ToString());
            Uri formattedUri = uriTemplate.BindByName(baseAddressUri, parameters);
            wc.UploadStringAsync(formattedUri, "POST");
        }
