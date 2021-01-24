c#
// assuming you have added Newtonsoft.JSON package and added the correct using statements
using (StreamWriter writer = new StreamWriter(myRequest.GetRequestStream()) {
    string json = JsonConvert.SerializeObject(infoParam);
    writer.WriteLine(json);
    writer.Flush();
}
You'll probably want to set various other request parameters, like the `Content-Type` header.
