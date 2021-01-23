    //using System.Dynamic;
    //using ImpromptuInterface;
    //using System.Linq;
    IEnumerable<string> list1 =Impromptu.GetMemberNames(obj1);
    list1 = list1.OrderBy(m=>m);
    IEnumerable<string> list2 =Impromptu.GetMemberNames(obj2);
    list2 = list2.OrderBy(m=>m);
    if(!list1.SequenceEqual(list2))
	 return false;
    foreach(var memberName in list1){
	 if(!Impromptu.InvokeGet(obj1, memberName).Equals(Impromptu.InvokeGet(obj2,memberName))){
		return false;
	 }
    }
    return true;
