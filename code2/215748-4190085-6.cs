    class Program
    {
    
      static void Main(string[] args)
      {
        var l1 = default(COWList);
        l1.Add("foo"); // initialize
        l1.Add("bar"); // no copy
        l1.Add("baz"); // no copy
        var l2 = l1;
        l1.RemoveAt(0); // copy
        l2.Add("foobar"); // no copy
        l1.Add("barfoo"); // no copy
        l2.RemoveAt(1); // no copy
        var l3 = l2;
        l3.RemoveAt(1); // copy
        Trace.WriteLine(l1.ToString()); //  bar baz barfoo
        Trace.WriteLine(l2.ToString()); // foo baz foobar
        Trace.WriteLine(l3.ToString()); // foo foobar
      }
    }
    struct COWList
    {
      List<string> theList; // Contains the actual data
      object dummy; // helper variable to facilitate detection of copies of this struct instance.
      WeakReference weakDummy; // helper variable to facilitate detection of copies of this struct instance.
    
      /// <summary>
      /// Check whether this COWList has already been constructed properly.  
      /// </summary>
      /// <returns>true when this COWList has already been initialized.</returns>
      bool EnsureInitialization()
      {
        if (theList == null)
        {
          theList = new List<string>();
          dummy = new object();
          weakDummy = new WeakReference(dummy);
          return false;
        }
        else
        {
          return true;
        }
      }
    
      void EnsureUniqueness()
      {
        if (EnsureInitialization())
        {
    
          // If the COWList has been copied, removing the 'dummy' reference will not kill weakDummy because the copy retains a reference.
          dummy = new object();
    
          GC.Collect(2); // OUCH! This is expensive. You may replace it with GC.Collect(0), but that will cause spurious Copy-On-Write behaviour.
          if (weakDummy.IsAlive) // I don't know if the GC guarantees detection of all GC'able objects, so there might be cases in which the weakDummy is still considered to be alive.
          {
            // At this point there is probably a copy.
            // To be safe, do the expensive Copy-On-Write
            theList = new List<string>(theList);
            // Prepare for the next modification
            weakDummy = new WeakReference(dummy);
            Trace.WriteLine("Made copy.");
    
          }
          else
          {
            // At this point it is guaranteed there is no copy.
            weakDummy.Target = dummy;
            Trace.WriteLine("No copy made.");
    
          }
        }
        else
        {
    
          Trace.WriteLine("Initialized an instance.");
    
        }
      }
    
      public void Add(string val)
      {
        EnsureUniqueness();
        theList.Add(val);
      }
    
      public void RemoveAt(int index)
      {
        EnsureUniqueness();
        theList.RemoveAt(index);
      }
    
      public override string ToString()
      {
        if (theList == null)
        {
          return "Uninitialized COWList";
        }
        else
        {
          var sb = new StringBuilder("[ ");
          foreach (var item in theList)
          {
            sb.Append("\"").Append(item).Append("\" ");
          }
          sb.Append("]");
          return sb.ToString();
        }
      }
    }
    
