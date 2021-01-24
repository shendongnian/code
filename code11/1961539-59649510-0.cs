    class MainForm
    {
        private class MainFormProgress : IProgress<Single>
        {
            private readonly ProgressBar pb;
            private const Int32 _max = 10000; // Using values above 100 animate smoother if the ProgressBar is wider than 100 pixels.
            public MainFormProgress( ProgressBar pb )
            {
                this.pb = pb ?? throw new ArgumentNullException(nameof(pb));
                this.pb.Minimum =    0;
                this.pb.Maximum = _max;
                this.pb.Value   =    0;
            }
            public void Report( Single value )
            {
                // You MAY need to wrap this in a call to BeginInvoke or Invoke if this is being run on a background thread.
                this.pb.Value = (Int32)( value * _max );
            }
        }
        void MethodA()
        {
            MainFormProgress progress = new MainFormProgress( this.progressBar );
            instanceOfClass1.MethodB( progress  );
            // ...
        }
    }
    class Class1
    {
        void MethodB( IProgress<Single> progress )
        {
           // ...
            // do something
            progress.Report( 0.1 ); // we're 10% complete!
            instanceOfClass2.MethodC( progress );
            progress.Report( 0.75 ); // we're 75% complete!
            // ...
       }
    }
    // etc for the other classes
