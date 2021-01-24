    //All employees of person A 
    var B = db.LeaveApplicationDbSet.Where(e => e.manager_id == "A");
    var C = new List<Employee>();
    
    //All employees from B
    foreach(var i in B){
    var D = db.LeaveApplicationDbSet.Where(e => e.manager_id == i.id).ToList();
    C.AddRange(D);
   }
 
