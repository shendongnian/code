        static private Dictionary<int,string> GetValues(string productsCellData)
        {
            // regular expression to split the data into an array, we need the ExplictCapture
            // to prevent c# capturing the ;#
            var regex = new Regex(@"((?<=\d);#|;#(?=\d))", RegexOptions.ExplicitCapture);
            // our array of data that has been processed.
            var productsCellsArray = regex.Split(productsCellData);
            Dictionary<int, string> productsDictionary = new Dictionary<int, string>();
            if (productsCellsArray.Length % 2 == 1)
            {
                // handle badly formatted string the array length should always be an even number.
            }
            // set local variables to hold the data in the loop.
            int productKey = -1;
            string productValue = string.Empty;
            // loop over the array and create our dictionary.
            for (var i = 0; i < productsCellsArray.Length; i++)
            {
                var item = productsCellsArray[i];
                // process odd/even
                switch (i % 2)
                { 
                    case 0:
                        productKey = Int32.Parse(item);
                        break;
                    case 1:
                        productValue = item;
                        if (productKey > 0)
                        {
                            productsDictionary.Add(productKey, productValue);
                            productKey = -1;
                            productValue = string.Empty;
                        }
                        break;
                }
            }
            return productsDictionary;
        }
