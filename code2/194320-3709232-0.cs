    public class Importer
    {
      private BlockingCollection<Person> m_Queue = new BlockingCollection<Person>();
    
      public Importer(int poolSize)
      {
        for (int i = 0; i < poolSize; i++)
        {
          var thread = new Thread(Download);
          thread.IsBackground = true;
          thread.Start();
        }
      }
    
      public void Add(Person person)
      {
        m_Queue.Add(person);
      }
    
      private void Download()
      {
        while (true)
        {
          Person person = m_Queue.Take();
          // Add your code for downloading this person's data here.
        }
      }
    }
