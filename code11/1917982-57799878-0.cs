    public async Task<ActionResult<Item>> GetItemByIdAsync()
        {
            string json = @"{
              'id': '2f5135a7-977c-4b26-a4e2-74b9e374a75e',
              'name': null,
             
            }";
            Item x = JsonConvert.DeserializeObject<Item>(json);//throw 500 error using your Item model
            return x;
        }
