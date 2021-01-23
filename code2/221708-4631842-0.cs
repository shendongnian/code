       public static void Main()
            {
                SignedRequestHelper helper = new SignedRequestHelper(MY_AWS_ACCESS_KEY_ID, MY_AWS_SECRET_KEY, DESTINATION);
    
                /*
                 * The helper supports two forms of requests - dictionary form and query string form.
                 */
                String requestUrl;
                String title;
    
                /*
                 * Here is an ItemLookup example where the request is stored as a dictionary.
                 */
                IDictionary<string, string> r1 = new Dictionary<string, String>();
                r1["Service"] = "AWSECommerceService";
                r1["Version"] = "2009-03-31";
                r1["Operation"] = "ItemLookup";
                r1["ItemId"] = ITEM_ID;
                r1["ResponseGroup"] = "Small";
    
                /* Random params for testing */
                r1["AnUrl"] = "http://www.amazon.com/books";
                r1["AnEmailAddress"] = "foobar@nowhere.com";
                r1["AUnicodeString"] = "αβγδεٵٶٷٸٹٺチャーハン叉焼";
                r1["Latin1Chars"] = "ĀāĂăĄąĆćĈĉĊċČčĎďĐđĒēĔĕĖėĘęĚěĜĝĞğĠġĢģĤĥĦħĨĩĪīĬĭĮįİıĲĳ";
    
                requestUrl = helper.Sign(r1);
                title = FetchTitle(requestUrl);
    
                System.Console.WriteLine("Method 1: ItemLookup Dictionary form.");
                System.Console.WriteLine("Title is \"" + title + "\"");
                System.Console.WriteLine();
    }
