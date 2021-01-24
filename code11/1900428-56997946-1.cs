public string TypeRadio { get; set; }
Then I altered the controller to set that differently-named property based on the original route parameter:
[HttpGet]
        public ActionResult Search(string requestType, string billNumber, string sessionNumber)
        {
            var searchModel = new SearchModel();
            string requestTypeLowerCase = string.Empty;
            if (!string.IsNullOrWhiteSpace(requestType))
            {
                requestTypeLowerCase = requestType.ToLower();
                searchModel.RequestType = requestTypeLowerCase;
                searchModel.TypeRadio = requestTypeLowerCase;
            } 
//etc...
}
Then I bound my radio buttons to that new, differently-named property:
@Html.RadioButtonFor(model => model.TypeRadio, "bill") Bill                        
@Html.RadioButtonFor(model => model.TypeRadio, "initiative") Initiative
@Html.RadioButtonFor(model => model.TypeRadio, "both") Both
Left the route the same, and everything worked, since (I guess?) now the radio button names have nothing to do with the route parameters.
Thanks for looking, but definitely feel free to enlighten me if you know why my original code didn't work!
         
