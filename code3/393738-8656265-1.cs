    ArrayList MyArray = new ArrayList();
    MyArray.Add("Audi");
    MyArray.Add("BMW");
    MyArray.Add("Ford");
    MyArray.Add("Vauxhall");
    MyArray.Add("Volkswagen");
    MyArray.Sort();
    MyDropDownList.DataSource = MyArray ;
    MyDropDownList.DataBind();
