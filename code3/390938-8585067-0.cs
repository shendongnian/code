                JavaScriptSerializer seri = new JavaScriptSerializer();
                var items = seri.Deserialize<Dictionary<string, object>>(jsonData);
    	    // As data in JSON is array get it deserialize as ArrayList of Dictionary<string,object>
                var dataArray =  items["data"] as ArrayList;	
    	    // Each item in array list contain key value pair of name and id
                foreach (Dictionary<string,object> item in dataArray)
                    {
    		//Read Item
                    foreach (KeyValuePair<string, object> detailItem in item)
                        {
                        Console.WriteLine(detailItem.Key + " - " + detailItem.Value);
                        }
                    Console.WriteLine("-------------------------------------------");
    		// Read Item
                    }
