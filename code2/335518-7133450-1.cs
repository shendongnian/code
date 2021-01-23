    using System.IO;
    // other includes
    public partial class MyForm : Form
    {
        public MyForm()
        {
            // you can add the button event 
            // handler in the designer as well
            someButton.Click += someButton_Click;
        }
        private void someButton_Click( object sender, EventArgs e )
        {
            PopulateList( "some file path here" );
        }
        private void PopulateList( string filePath )
        {
            var items = new List<string>();
            using( var stream = File.OpenRead( filePath ) )  // open file
            using( var reader = new TextReader( stream ) )   // read the stream with TextReader
            {
                string line;
            
                // read until no more lines are present
                while( (line = reader.ReadLine()) != null )
                {
                    items.Add( line );
                }
            }
        
            // add the ListBox items in a bulk update instead of one at a time.
            listBox.AddRange( items );
        }
    }
