    // service
    delegate void ProgressDelegate( int CurrentValue, int MaxValue );
    void BusinessProcess( ProgressDelegate progress )
    {
       // do something
       progress( 20, 100 );
       // do other things
       progress( 50, 100 );
       // do yet another thing
       progress( 100, 100 );
    }
    // client
    
    void Button1_Click( object sender, EventArgs e )
    {
       BusinessProcess(
          (current, max ) => 
          {
             this.ProgressBar1.Maximum = max;
             this.ProgressBar1.Value = current;
             this.ProgressBar1.Refresh();
          }
          );
    }
