using System;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
   public class A
   {
      B m_b = new B();
      public void RegisterEventHandlers()
      {
         m_b.TheEvent += new EventHandler(Handler_TheEvent);
         m_b.TheEvent += new EventHandler(AnotherHandler_TheEvent);
      }
      public A()
      { 
         m_b.TheEvent += new EventHandler(InitialHandler_TheEvent);
      }
      void InitialHandler_TheEvent(object sender, EventArgs e)
      { }
      void Handler_TheEvent(object sender, EventArgs e)
      { }
      void AnotherHandler_TheEvent(object sender, EventArgs e)
      { }
   }
   public class B
   {
      public event EventHandler TheEvent;
      //{
      //   //Note that if we declared TheEvent without the add/remove methods, the
      //   //following would still generated internally and the underlying member
      //   //(here m_theEvent) can be accessed via Reflection. The automatically
      //   //generated version has a private field with the same name as the event
      //   //(i.e. "TheEvent")
      //   add { m_theEvent += value; }
      //   remove { m_theEvent -= value; }
      //}
      //EventHandler m_theEvent; //"TheEvent" if we don't implement add/remove
      //The following shows how the event can be invoked using the underlying multicast delegate.
      //We use this knowledge when invoking via reflection (of course, normally we just write
      //if (TheEvent != null) TheEvent(this, EventArgs.Empty)
      public void ExampleInvokeTheEvent()
      {
         Delegate[] dels = TheEvent.GetInvocationList();
         foreach (Delegate del in dels)
         {
            MethodInfo method = del.Method;
            //This does the same as ThisEvent(this, EventArgs.Empty) for a single registered target
            method.Invoke(this, new object[] { EventArgs.Empty });
         }
      }
   }
   public class Test
   {
      List&lt;Delegate&gt; FindRegisteredDelegates(A instanceRegisteringEvents, B instanceWithEventHandler, string sEventName)
      {
         A a = instanceRegisteringEvents;
         B b = instanceWithEventHandler;
         //Lets assume that we know that we are looking for a private instance field with name sEventName ("TheEvent"), 
         //i.e the event handler does not implement add/remove.
         //(otherwise we would need more reflection to determine what we are looking for)
         BindingFlags filter = BindingFlags.Instance | BindingFlags.NonPublic;
         //Lets assume that TheEvent does not implement the add and remove methods, in which case
         //the name of the relevant field is just the same as the event itself
         string sName = sEventName; //("TheEvent")
         FieldInfo fieldTheEvent = b.GetType().GetField(sName, filter);
         //The field that we get has type EventHandler and can be invoked as in ExampleInvokeTheEvent
         EventHandler eh = (EventHandler)fieldTheEvent.GetValue(b);
         //If the event handler is null then nobody has registered with it yet (just return an empty list)
         if (eh == null) return new List&lt;Delegate&gt;();
         List&lt;Delegate&gt; dels = new List&lt;Delegate&gt;(eh.GetInvocationList());
         //Only return those elements in the invokation list whose target is a.
         return dels.FindAll(delegate(Delegate del) { return Object.ReferenceEquals(del.Target, a); });
      }
      public void Run()
      {
         A a = new A();
         //We would need to check the set of delegates returned before we call this
         //Lets assume we know how to find the all instances of B that A has registered with
         //For know, lets assume there is just one in the field m_b of A.
         FieldInfo fieldB = a.GetType().GetField("m_b", BindingFlags.Instance | BindingFlags.NonPublic);
         B b = (B)fieldB.GetValue(a);
         //Now we can find out how many times a.RegisterEventHandlers is registered with b
         List&lt;Delegate&gt; delsBefore = FindRegisteredDelegates(a, b, "TheEvent");
         a.RegisterEventHandlers();
         List&lt;Delegate&gt; delsAfter = FindRegisteredDelegates(a, b, "TheEvent");
         List&lt;Delegate&gt; delsAdded = new List&lt;Delegate&gt;();
         foreach (Delegate delAfter in delsAfter)
         {
            bool inBefore = false;
            foreach (Delegate delBefore in delsBefore)
            {
               if ((delBefore.Method == delAfter.Method)
                  && (Object.ReferenceEquals(delBefore.Target, delAfter.Target)))
               {
                  //NOTE: The check for Object.ReferenceEquals(delBefore.Target, delAfter.Target) above is not necessary 
                  //     here since we defined FindRegisteredDelegates to only return those for which .Taget == a)
                  inBefore = true;
                  break;
               }
            }
            if (!inBefore) delsAdded.Add(delAfter);
         }
         Debug.WriteLine("Handlers added to b.TheEvent in a.RegisterEventHandlers:");
         foreach (Delegate del in delsAdded)
         {
            Debug.WriteLine(del.Method.Name);
         }
      }
   }
