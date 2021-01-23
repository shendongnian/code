    var r1 = objDataSet.Tables[1].Rows;
    var r2 = r1.Cast<DataRow>();
    System.Diagnostics.Debug.Print("r2: {0}", r2.Count());
    var r3 = r2.Where(p => Convert.ToDecimal(p["EMG_MARKS_ABOVE"]) <= extSubMarks  
                && extSubMarks <= Convert.ToDecimal(p["EMG_MARKS_BELOW"]));
    System.Diagnostics.Debug.Print("r3: {0}", r3.Count());
    var r4 = r3.Select(p => Convert.ToString(p["EMG_GRADE_NAME"]));
    var r5 = r4.First();
    
    newGradeRow[rowCnt + 1 + "Grade " + ExamName] = r5;
 
