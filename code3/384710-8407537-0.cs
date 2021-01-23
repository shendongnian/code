    if(cell.OwningColumn.IsDataBound)
    {
        Member member = new Member();
        //switch statement or you can use reflection
        switch(cell.OwningColumn.DataPropertyName)
        {
            case "name":
                 member.Name=cell.Value;//need cast
            ....
        }
    }
