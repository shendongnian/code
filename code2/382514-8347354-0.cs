    public int MyFieldID = 0;
    public string MyStringFromDB = string.empty;
    // PAGE LOAD GET DB VALUES
    {
        MyFieldID = Convert.ToInt32(db["ID"]);
        MyStringFromDB = Convert.ToString(db["FIELD"]);
    }
