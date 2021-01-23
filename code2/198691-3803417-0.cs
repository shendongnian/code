     WebClient wc = new WebClient();
     //call URL with your data
     var res = wc.UploadData("linkedinurl", System.Text.Encoding.ASCII.GetBytes(querystrings));
     //parse the returned results
     var result= System.Convert.ToInt32(Encoding.ASCII.GetString(res));
