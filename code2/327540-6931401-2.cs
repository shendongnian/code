    protected override void Dispose(bool disposing)
    {
       System.Diagnostics.Trace.WriteLine(
          "Form1.Dispose " + (disposing ? "disposing " : "")
          + this.GetHashCode().ToString());
       base.Dispose (disposing);
    }
