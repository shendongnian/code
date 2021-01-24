    using System.IO;
    using System.Linq;
    IEnumerable<String> fileNames = new DirectoryInfo( rootDirectoryPath )
        .EnumerableFiles( "fileServer.config", SearchOption.AllDirectories )
        .Select( fi => fi.FullName );
    String allNames = String.Join( "\r\n\r\n", fileNames );
    MessageBox.Show( allNames );
 
