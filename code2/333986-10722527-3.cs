    /// <summary>
    /// Loads singleton instance of ResourceDictionary to current scope;
    /// </summary>
    public class SharedResourceDictionary : ResourceDictionary
    {
      /// <summary>
      /// store weak references to loaded ResourceDictionary, to ensure that ResourceDictionary won't be instanciated multiple times
      /// </summary>
      protected static Dictionary<string, WeakReference> SharedResources = new Dictionary<string, WeakReference>();
    
      public string SharedSource
      {
        get { return _SharedSource; }
        set
        {
          if (_SharedSource != value)
          {
            _SharedSource = value;
            sharedSourceChanged();
          }
        }
      }
      private string _SharedSource;
    
    
      private void sharedSourceChanged()
      {
        //ResourceDictionary will be instanciated only once
        ResourceDictionary sharedResourceDictionary;
    
        lock (SharedResources)
        {
          WeakReference weakResourceDictionary = null;
          if (SharedResources.ContainsKey(_SharedSource))
          {
            weakResourceDictionary = SharedResources[_SharedSource];
          }
          else
          {
            SharedResources.Add(_SharedSource, null);
          }
    
          if (weakResourceDictionary == null || !weakResourceDictionary.IsAlive) //load ResourceDictionary or get reference to exiting
          {
            sharedResourceDictionary = (ResourceDictionary)Application.LoadComponent(new Uri(_SharedSource, UriKind.Relative));
            weakResourceDictionary = new WeakReference(sharedResourceDictionary);
          }
          else
          {
            sharedResourceDictionary = (ResourceDictionary)weakResourceDictionary.Target;
          }
    
          SharedResources[_SharedSource] = weakResourceDictionary;
        }
    
    
        if (Application.Current != null)
        {
          //if sharedResourceDictionary is defined in application scope do not add it to again to current scope
          if (containsResourceDictionary(Application.Current.Resources, sharedResourceDictionary))
          {
            return;
          }
        }
    
        this.MergedDictionaries.Add(sharedResourceDictionary);
      }
    
      private bool containsResourceDictionary(ResourceDictionary scope, ResourceDictionary rs)
      {
        foreach (var subScope in scope.MergedDictionaries)
        {
          if (subScope == rs) return true;
          if (containsResourceDictionary(subScope, rs)) return true;
        }
        return false;
      }
    }
