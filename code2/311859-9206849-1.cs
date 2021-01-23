    for (int i = 0; i < interestedIN.Items.Count; i++)
    {
       if (interestedIN.Items[i].Selected)
       {
           values += interestedIN.Items[i].Value + ",";
       }
    }
    values = values.TrimEnd(',');
