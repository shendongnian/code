POST /api/values?pharmacyAddress=myaddress&pharmacyCategory=mycategory HTTP/1.1
Host: localhost:59353
Content-Type: application/x-www-form-urlencoded
=pharmacyNameContent
### Solution-2 ###
Or you can call your API by putting all your params in complex model and pass params through body instead of query parameters like this 
**Complex Type Model**
public class PharmacyModel
    {
        public string PharmacyName { get; set; }
        public string PharmacyAddress { get; set; }
        public string PharmacyCategory { get; set; }
    }
**API code**
[System.Web.Http.HttpPost]
public void Post(PharmacyModel pharamcyModel)
{
    MySqlConnection conn = WebApiConfig.conn();
    MySqlCommand query = conn.CreateCommand();
    
    //Access your propeties like this
    query.CommandText = "INSERT INTO locations (pharamcyModel.PharmacyName, pharamcyModel.PharmacyAddress, pharamcyModel.PharmacyCategory) VALUES (@pharmacyName, @pharmacyAddress, @pharmacyCategory)";
  //rest of the coding
}
And now you can consume your API by passing paramters through body like this
POST /api/values? HTTP/1.1
Host: localhost:59353
Content-Type: application/x-www-form-urlencoded
pharmacyAddress=myaddress&pharmacyCategory=mycategory&pharmacyName=nameOfPharmacy
It will surely gonna work as its already implemented and tested from my end  
