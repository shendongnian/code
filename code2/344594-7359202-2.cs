       arrEmpID.Add(1);
        arrEmpID.Add(1);
        arrEmpID.Add(2);
        arrEmpID.Add(2);
        arrPay.Add(1);
        arrPay.Add(1);
        arrPay.Add(2);
        arrPay.Add(2);
        DateTime dt = DateTime.Now;
        DateTime dt1 = DateTime.Now.AddMinutes(1);
        DateTime dt2 = DateTime.Now.AddMinutes(1);
        DateTime dt3 = DateTime.Now.AddMinutes(1);
        arrPayID.Add(dt);
        arrPayID.Add(dt1);
        arrPayID.Add(dt2);
        arrPayID.Add(dt3);
        EmpIDs = (int[])arrEmpID.ToArray(typeof(int));
        Dates = (DateTime[])arrPayID.ToArray(typeof(DateTime));
        PayIDs = (int[])arrPay.ToArray(typeof(int));
    for (int i = 0; i < EmpIDs.Length; i++)
        {
            if (!(d.ContainsKey(EmpIDs[i])))
            {
                List<int> values = new List<int>();
                List<DateTime> ldt = new List<DateTime>();
                d.Add(EmpIDs[i], values, ldt);
            }
            d[EmpIDs[i]].lst.Add(PayIDs[i]);
            d[EmpIDs[i]].lstdt.Add(Dates[i]);
        }
       foreach (int EmpID in d.Keys)
        {
            foreach (int pID in d[EmpID].lst) // I just missed out this values
            {
                sb.Append(pID);
                sb.AppendLine(" ");
            }
            foreach (DateTime dtTimes in d[EmpID].lstdt)  // I just missed out this values
            {
               
                sb1.Append(dtTimes.ToString("MMddyyyy"));
                sb1.AppendLine(" ");
            }
        }
        Label1.Text = sb.ToString();
        Label2.Text = sb1.ToString();
