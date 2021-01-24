    public class Result
    {
         public string Number {get; set;}
         .
         .
         .
    }
    .
    .
    .
    //in your "Get" method change the return for the class type
    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
    {
        var res = new StreamReader(response.GetResponseStream()).ReadToEnd();
        return JsonConvert.DeserializeObject<Result>(res);
    };
    .
    .
    .
    //if you need to get 'callNumber'
    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
    {
        var res = new StreamReader(response.GetResponseStream()).ReadToEnd();
        var obj = JsonConvert.DeserializeObject<Result>(res);
        var callNumber = obj.Number;
        return obj;
    };
