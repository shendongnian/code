    // Define the regex patterns to use
    string lattPattern = "(Latitude\\s\\(decimal\\sdegrees\\):)(\\t\\d+\\.*\\d*)";
    string longPattern = "(Longitude\\s\\(decimal\\sdegrees\\):)(\\t\\d+\\.*\\d*)";
    string radDbPattern = "(Radiation\\sdatabase\\:)(\\t)(PVGIS\\-CMSAF)";
    string osaPattern = "((19|20)\\d{2})(\\t\\t)([A-Z]+[a-z]*)(\\t\\t\\d+\\.*\\d*)";
    // Create the matches for the top-level data
    var lattitude = Regex.Match(apiStringData, lattPattern);
    var longitude = Regex.Match(apiStringData, longPattern);
    var radDb = Regex.Match(apiStringData, radDbPattern);
    // Create the result object, and populate the top-level properties
    ApiData apiObject = new ApiData();
    apiObject.Latitude = Convert.ToDecimal(lattitude.Groups[2].ToString());
    apiObject.Longitude = Convert.ToDecimal(longitude.Groups[2].ToString());
    apiObject.RadiationDatabase = radDb.Groups[3].ToString();
    // Split the sample data into an array 
    // to make it easier to enumerate what will become the nested data
    string[] apiArray = Regex.Split(apiStringData, "\r\n");
    // Step through it
    foreach (string s in apiArray)
    {
        var angle = Regex.Match(s, osaPattern, RegexOptions.IgnoreCase);
        if (angle.Success == true)
        {
            // Create the properties
            int year = Convert.ToInt32(angle.Groups[1].ToString());
            string month = angle.Groups[4].ToString();
            decimal hh = Convert.ToDecimal(angle.Groups[5].ToString());
            // Add to the collection
            ApiSlopeAngle apiDate = new ApiSlopeAngle(year, month, hh);
            apiObject.OptimalSlopeAngle.Add(apiDate);
        }
    }
