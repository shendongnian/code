    //Change your ItemViewModel like
    public class ItemViewModel
    {
        public string name { get; set; }
        public string TotalPrice { get; set; }
    }
    //Introduce your custom Parser to handle the comma case
    private  bool MyTryParse(string toParse, out decimal result)
    {
        //Remove commas
        string formatted = toParse.Replace(",", "");
        
        return decimal.TryParse(formatted, out result);
    }
    
    //And your controller be like
    [HttpPost]
    [MultipleButton(Name = "action", Argument = "Submit")]
    public ActionResult Submit(ItemViewModel model)
    {
        decimal a = null;
    
        if (MyTryParse(model.TotalPrice, out a))
        {
            //Success code
        }
        else
        {
            //some error code
        }
    
        Console.WriteLine(a);
    }
