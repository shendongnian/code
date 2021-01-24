    static NumericUpDown[] tabGrades = new NumericUpDown[5];
    //Here use whatever length you want instead of 10.
    NumericUpDown[][] tempGrades = new NumericUpDown[10][tabGrades.Length]; 
    
    ...
    
    tempGrades[0][0] = tabGrades;
