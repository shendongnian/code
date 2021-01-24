        public virtual void DoChores(FamilyBase member)
        {
            Console.WriteLine("Doing Chores by: "+member);
        }
    }
    public class Parent: FamilyBase
    {
        public Parent()
        {
            
        }
        private List<FamilyBase> family=new List<FamilyBase>();
        
        public void AddMember(FamilyBase member)
        {
            family.Add(member);
        }
        //send out chores
        public void SendOutMessages()
        {
          if(family.Count>0)
          {
              foreach(var member in family)
              {
                  member.DoChores(member);
              }
          }
        }
    }
    public class ChildA:FamilyBase
    {
        public ChildA()
        {
            
        }
    }
    public class ChildB:FamilyBase
    {
        public ChildB()
        {
            
        }
        public override void DoChores(FamilyBase member)
        {
            Console.WriteLine("I'm doing my homework first.");
            base.DoChores(member);
        }
    }
