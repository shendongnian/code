    for(int j = 0; j<intensityList.Count; j++) {
                getIntensityofMode(intensityList[j]);
                Report.Log(ReportLevel.Info, "");
                Console.ReadLine();
            }
        }
    public void getIntensityofMode(HelpingClasses.IntensityData mode) {
    
    	Type type = typeof(HelpingClasses.IntensityData);
    	PropertyInfo[] properties = type.GetProperties();
    	foreach (PropertyInfo property in properties)
    	{
    		if(property.GetValue(mode, null) != null) {
                var value = property.GetValue(mode, null);
                // Test if it is IEnumerable and cast it if so
                if (value is IEnumerable e) {
                    // Print the value of elements in the enumerable list
                    foreach (var v in e) {
        			    Report.Log(ReportLevel.Info, property.Name + " = " + value.ToString());
                    }
                } else {
    			   Report.Log(ReportLevel.Info, property.Name + " = " + value);
                }
            }
    	}
    }
