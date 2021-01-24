    public class Testing
    {
        [Test]
        public void Deserialize()
        {
            var page = JsonConvert.DeserializeObject<PagedResult<ApplicationUser>>(json);
            var users = page.result;
            Assert.IsNotNull(users[0].userName.Equals("SamPowell"));
        }    
   
         private string json = @""; //your json
    }
