    public class Searcher
    {
      private BlockingCollection<DirectoryInfo> m_Queue = new BlockingCollection<DirectoryInfo>();
    
      public Searcher()
      {
        for (int i = 0; i < NUMBER_OF_THREADS; i++)
        {
          var thread = new Thread(Run);
          thread.IsBackground = true;
          thread.Start();
        }
      }
    
      public void Search(DirectoryInfo root)
      {
        m_Queue.Add(root);
      }
    
      private void Run()
      {
        while (true)
        {
          DirectoryInfo root = m_Queue.Take();
          foreach (DirectoryInfo child in root.GetDirectories())
          {
            // Add each child directory to the queue. This is the recursive part.
            m_Queue.Add(child);
          }
          foreach (FileInfo child in root.GetFiles())
          {
            // Add your search logic here.
          }
        }
      }
    }
