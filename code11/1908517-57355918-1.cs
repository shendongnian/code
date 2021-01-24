            var data = JsonConvert.DeserializeObject<dynamic>(jsonString);
            // The keys you have to search through.
            string[] keysToSearchThrough = new string[] { "characterKey", "charName" };
            string result = string.Empty;
            // The current data it is travesing through
            Dictionary<string, dynamic> currTraversedData = data.ToObject<Dictionary<string, dynamic>>();
            for (int i = 0; i < keysToSearchThrough.Length; ++i) {
                if (currTraversedData.ContainsKey(keysToSearchThrough[i])) {
                    // Get the value if the key current exists
                    dynamic currTravesedDataValue = currTraversedData[keysToSearchThrough[i]];
                    // Check if this 'currTravesedDataValue' can be converted to a 'Dictionary<string, dynamic>'
                    if (IsStringDynamicDictionary(currTravesedDataValue)) {
                        // There is still more to travese through
                        currTraversedData = currTravesedDataValue.ToObject<Dictionary<string, dynamic>>();
                    } else {
                        // There is no more to travese through. (This is the result)
                        result = currTravesedDataValue.ToString();
                        // TODO: Some error checking in the event that we reached the result early, even though we still have more keys to travase through
                        break;
                    }
                } else {
                    // One of the keys to search through was probably invalid.
                }
            }
            // ...
            bool IsStringDynamicDictionary(dynamic input) {
                try {
                    input.ToObject<Dictionary<string, dynamic>>();
                    return true;
                } catch (Exception) {
                    return false;
                }
            }
