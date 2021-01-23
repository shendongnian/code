    public class Base
    {
        public string Name { get; set; }
    }
    public class Derived : Base { }
    
    //in Main
    var parentMember = typeof(Base).GetMember("Name")[0];
    var childMember = typeof(Derived).GetMember("Name")[0];
    Expression<Func<Base, string>> parentExp = x => x.Name;
    var parentExpMember = (parentExp.Body as MemberExpression).Member;
    Expression<Func<Derived, string>> childExp = x => x.Name;
    var childExpMember = (childExp.Body as MemberExpression).Member;
    parentMember == childMember  //false, good
    parentMember == parentExpMember  //true, good
    childMember == childExpMember   //false, why?
