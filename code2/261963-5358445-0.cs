    foreach(Control c in this.Controls)
     {
        if(c is dropdownlist)
        {
            dropdownlist dl = (dropdownlist)c;
            if (i % 5 > 0)
            {
               dl.items[i].Attributes.Add("disabled","disabled");
            }
        }
     }
