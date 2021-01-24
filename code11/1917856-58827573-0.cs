    FirebaseResponse response = await firebaseClient.GetAsync("suppliers");
    JObject jsonResponse = response.ResultAs<JObject>();
    var query = new List<SupplierModel>();
    if (jsonResponse != null)
    {
    foreach (var item in jsonResponse)
            {
             var value = item.Value.ToString();
             var supplierModel = JsonConvert.DeserializeObject<SupplierModel>(value);
             //note: supplier model should have id attribute
             supplierModel.Id = item.Key;
             query.Add(supplierModel);
            };
     }
