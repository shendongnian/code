     string input = "backup-2011-10-12T17-16-51.zip";
    
                string[] splitInputs = input.Split('-');
    
                DateTime inputDate = new DateTime(
                    int.Parse(splitInputs[1]), //Year
                    int.Parse(splitInputs[2]), //Month
                    int.Parse(splitInputs[3].Split('T')[0]), //Day left of the T 
                    int.Parse(splitInputs[3].Split('T')[1]), //Hour, right of the T
                    int.Parse(splitInputs[4]), //Minutes
                    int.Parse(splitInputs[5].Split('.')[0])); //Seconds, left of the .zip
