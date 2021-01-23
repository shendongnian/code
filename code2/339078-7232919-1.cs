    //using System.Dynamic;
    //using Dynamitey;
    //using System.Linq;
    IEnumerable<string> list1 =Dynamic.GetMemberNames(obj1);
    list1 = list1.OrderBy(m=>m);
    IEnumerable<string> list2 =Dynamic.GetMemberNames(obj2);
    list2 = list2.OrderBy(m=>m);
    if(!list1.SequenceEqual(list2))
	 return false;
    foreach(var memberName in list1){
	 if(!Dynamic.InvokeGet(obj1, memberName).Equals(Dynamic.InvokeGet(obj2,memberName))){
		return false;
	 }
    }
    return true;
