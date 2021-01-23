    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Windows;
    void StringReplace_vs_StringBuilderReplace( string file, string word1, string word2 )
    {
        using( FileStream fileStream = new FileStream( file, FileMode.Open, FileAccess.Read ) )
        using( StreamReader streamReader = new StreamReader( fileStream, Encoding.UTF8 ) )
        {
            string text = streamReader.ReadToEnd(),
                   @string = text;
            StringBuilder @StringBuilder = new StringBuilder( text );
            int iterations = 10000;
            
            Stopwatch watch1 = new Stopwatch.StartNew();
            for( int i = 0; i < iterations; i++ )
                if( i % 2 == 0 ) @string = @string.Replace( word1, word2 );
                else @string = @string.Replace( word2, word1 );
            watch1.Stop();
            double stringMilliseconds = watch1.ElapsedMilliseconds;
                
            Stopwatch watch2 = new Stopwatch.StartNew();
            for( int i = 0; i < iterations; i++ )
                if( i % 2 == 0 ) @StringBuilder = @StringBuilder .Replace( word1, word2 );
                else @StringBuilder = @StringBuilder .Replace( word2, word1 );
            watch2.Stop();
            double StringBuilderMilliseconds = watch1.ElapsedMilliseconds;
                
            MessageBox.Show( string.Format( "string.Replace: {0}\nStringBuilder.Replace: {1}",
                                            stringMilliseconds, StringBuilderMilliseconds ) );
        }
    }
