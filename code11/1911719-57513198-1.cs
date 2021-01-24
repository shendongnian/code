    INumberList values = new INumberList();
            values.Add("cohabitantGender");
            values.Add("additionalDriver0LastName");
            values.Add("additionalDriver0AgeWhenLicensed");
            values.Add("vehicle0City");
            values.Add("vehicle1City");
            values.Add("vehicle2City");
            values.Add("vehicle3City");
    //Get filtered index list with multiple exclusion option
    List<int> indexList = values.ExcludeIndex("cohabitantGender","")
                            .ExcludeIndex("additionalDriver","AgeWhenLicensed")
                            .GetNumberList(); 
    //will return [0,0,1,2,3]
