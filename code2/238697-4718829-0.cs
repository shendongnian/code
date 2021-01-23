    using System.Web.UI;
    ... in your page class:
    PageStatePersister pageStatePersister;
    protected override PageStatePersister PageStatePersister
    {
      get
      {
        // Unlike as exemplified in the MSDN docs, we cannot simply return a new PageStatePersister
        // every call to this property, as it causes problems
        return pageStatePersister ?? (pageStatePersister = new BetterSessionPageStatePersister(this));
      }
    }
        
    ... in your BetterSessionPageStatePersister.cs:
    /// <summary>
    /// This class allows the viewstate to be kept server-side, so that postbacks are as small as possible.
    /// It is similar to the built-in 'SessionPageStatePersister', but it yields smaller postbacks,
    /// because the SessionPageStatePersister still leaves some viewstate (possibly it leaves the controlstate)
    /// in the postback.
    /// </summary>
    class BetterSessionPageStatePersister : PageStatePersister
    {
      public BetterSessionPageStatePersister(Page page)
        : base(page)
      { }
      const string ViewStateFieldName = "__VIEWSTATEKEY";
      const string ViewStateKeyPrefix = "ViewState_";
      const string RecentViewStateQueue = "ViewStateQueue";
      const int RecentViewStateQueueMaxLength = 5;
      public override void Load()
      {
        // The cache key for this viewstate is stored in a hidden field, so grab it
        string viewStateKey = Page.Request.Form[ViewStateFieldName] as string;
        // Grab the viewstate data using the key to look it up
        if (viewStateKey != null)
        {
          Pair p = (Pair)Page.Session[viewStateKey];
          ViewState = p.First;
          ControlState = p.Second;
        }
      }
      public override void Save()
      {
        // Give this viewstate a random key
        string viewStateKey = ViewStateKeyPrefix + Guid.NewGuid().ToString();
        // Store the view and control state
        Page.Session[viewStateKey] = new Pair(ViewState, ControlState);
        // Store the viewstate's key in a hidden field, so on postback we can grab it from the cache
        Page.ClientScript.RegisterHiddenField(ViewStateFieldName, viewStateKey);
        // Some tidying up: keep track of the X most recent viewstates for this user, and remove old ones
        var recent = Page.Session[RecentViewStateQueue] as Queue<string>;
        if (recent == null) Page.Session[RecentViewStateQueue] = recent = new Queue<string>();
        recent.Enqueue(viewStateKey); // Add this new one so it'll get removed later
        while (recent.Count > RecentViewStateQueueMaxLength) // If we've got lots in the queue, remove the old ones
          Page.Session.Remove(recent.Dequeue());
      }
    }
