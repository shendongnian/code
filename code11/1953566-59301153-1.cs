    var datalist = entities.StudentsData.OrderBy(stud => stud.id);
    //filterCondition contains the filter values
    if(filterCondition.Age.HasValue) 
    {
      datalist = datalist.Where(stud => stud.Age == filterCondition.Age);
    }
    if(filterCondition.Gender.HasValue)
    {
      datalist = datalist.Where(stud => 
      stud.Gender.Equals(filterCondition.Gender))
    }
    //More filters can be added as per your requirement. 
    datalist.ToList();
