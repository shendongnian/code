    namespace WebsiteScreeshot {
      class Program {
        static void Main ( string[] args ) {
          if ( args.Length != 2 ) {
            Console.WriteLine( "You need to provide URL and image" );
            return;
          }
          Xpcom.Initialize( @"C:\Libs\xulrunner" );
          var browser = new GeckoWebBrowser();
          browser.CreateControl();
          while ( !browser.IsHandleCreated ) {
            System.Threading.Thread.Sleep( 200 );
            System.Windows.Forms.Application.DoEvents();
          }
          browser.Navigate( args[0] );
          while ( browser.IsBusy ) {
            System.Threading.Thread.Sleep( 200 );
            System.Windows.Forms.Application.DoEvents();
          }
          browser.Width = 1044;
          browser.Height = 768;
          using ( Bitmap bmp = new Bitmap( 1024, 768 ) ) {
            Rectangle rec = new Rectangle( 0, 0, 1024, 768 );
            browser.DrawToBitmap( bmp, rec );
            bmp.Save( args[1] );
          }
          browser = null;
        }
      }
    }
