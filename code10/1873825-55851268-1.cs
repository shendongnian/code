    if(fee != null){
                     var query = retrive.Students
                     .Where(s => s.Year == year && s.Fees==fee).ToList();
                    searchedStudent.AddRange(query);
                    retrive.SaveChanges();
    }else{                                                              
                   var query = retrive.Students
                     .Where(s => s.Year == year).ToList();
                    searchedStudent.AddRange(query);
                    retrive.SaveChanges();
    }
