    System.Net.WebRequest request = System.Net.WebRequest.Create("http://panonest.com" + imageName);
    System.Net.WebResponse response = request.GetResponse();
    System.IO.Stream responseStream = response.GetResponseStream();
    Bitmap bitmap2 = new Bitmap(responseStream);
    bitmap2.Save("~/view/vacantapredeal/vacantapredeal.jpg");
