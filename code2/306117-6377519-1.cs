    var url = @"..."; 
	var nvc = new System.Collections.Specialized.NameValueCollection();
	nvc.Add("username", "username");
	nvc.Add("password", "password");
	var client = new System.Net.WebClient();
	var data = client.UploadValues(url, nvc);
	var res = System.Text.Encoding.ASCII.GetString(data);
	Console.WriteLine(res);
	Console.ReadLine();
