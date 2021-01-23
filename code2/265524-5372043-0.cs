    DropDownList[] arrDDL = new DropDownList[] { Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10 };
    Dictionary<int, string> strQandA = new Dictionary<int, string>();
    for (int i = 0; i < arrDDL.Length; i++)
       strQandA.Add(i + 1, arrDDL[i].SelectedValue);
    Session["mySession"] = strQandA;
