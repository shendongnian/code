    string score = dr["Weightage"].Text;  //save current value from "Weightage"
    string[] scores = score.split('-');   //splits it into 2 parts
    DT.Columns.Remove("Weightage");       //remove old column
    DT.Columns.Add("WeightageA");         //create new columns
    DT.Columns.Add("WeightageB");
    dr["WeightageA"] = scores[0];         //set column values
    dr["WeightageB"] = scores[1];
