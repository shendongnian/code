    public class ExampleGrid : RadGrid
    {
          public ExampleGrid() : base()
          {
               base.ItemInserted += (o, e) => NotifySomethingChanged();
               base.ItemDeleted += (o,e) => NotifySomethingChanged();
               base.ItemUpdated += (o,e) => NotifySomethingChanged();
          }
          public event EventHandler SomethingChanged;
          private void NotifySomethingChanged()
          {
                 var handler = this.SomethingChanged;
                 if (handler != null)
                      handler(this, EventArgs.Empty);
          }
      }
